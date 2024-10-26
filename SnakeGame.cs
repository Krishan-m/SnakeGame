using SnakeGame.Properties;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Timers;

namespace SnakeGame
{
	public partial class FormSnakeGame : Form
	{
		private int totalBoxes;
		private int boxesInRow;
		private int boxesInColumn;
		private int score;
		private int boxSize;
		private int direction; // 0: Up, 1: Right, 2: Down, 3: Left
		private List<Point> snake;
		private readonly Random random = new();
		private Point bait;
		private PictureBox baitBox;

		public FormSnakeGame()
		{
			InitializeComponent();
			StartGame();
		}
		private void StartGame()
		{
			totalBoxes = 0;
			boxesInRow = 0;
			boxesInColumn = 0;
			score = 0;
			boxSize = 50;
			direction = 1;
			timerGameLoop.Interval = 150; // Snake speed
			baitBox = new PictureBox()
			{
				Size = new Size(boxSize, boxSize),
				Image = Resources.apple,
				BorderStyle = BorderStyle.None,
				SizeMode = PictureBoxSizeMode.StretchImage,
				BackColor = Color.Transparent
			};
			grpbxGameGrid.Controls.Add(baitBox);
			CreateGrid();
			Point startingBox = GetStartingPoint();
			snake = new List<Point> { startingBox };
			timerGameLoop.Start();
			CreateSnake();
			CreateBait();
		}

		private void CreateGrid()
		{
			int winWidth = grpbxGameGrid.Width;
			int winHeight = grpbxGameGrid.Height;
			boxesInRow = winWidth / boxSize;
			boxesInColumn = winHeight / boxSize;
			totalBoxes = boxesInRow * boxesInColumn;

			for (int row = 0; row < boxesInRow; row++)
			{
				for (int column = 0; column < boxesInColumn; column++)
				{
					Color boxColor = ((row + column) % 2 == 0) ? Color.Green : Color.DarkGreen;
					Label gridBox = new Label()
					{
						Location = new Point(row * boxSize, column * boxSize),
						Size = new Size(boxSize, boxSize),
						BackColor = boxColor,
						BorderStyle = BorderStyle.None,
						Name = $"grid{row}-{column}",
					};
					gridBox.BorderStyle = BorderStyle.None;
					grpbxGameGrid.Controls.Add(gridBox);
				}
			}
			grpbxGameGrid.SendToBack();
		}

		private void CreateSnake()
		{
			Color snakeColor = Color.SkyBlue;

			// Remove previous snake box
			foreach (Control c in grpbxGameGrid.Controls)
			{
				if (c is PictureBox p)
				{
					if (p.Name.StartsWith("snake-box"))
					{
						grpbxGameGrid.Controls.Remove(c);
					}
				}
			}

			PictureBox snakeBox;
			snakeBox = new PictureBox()
			{
				Size = new Size(boxSize, boxSize),
				Location = snake[0],
				Image = Resources.snake_head,
				Name = "snake-box-0",
				BorderStyle = BorderStyle.None,
			};
			grpbxGameGrid.Controls.Add(snakeBox);
			snakeBox.BringToFront();
			if (snake.Count > 1)
			{
				foreach (Point p in snake.GetRange(1, snake.Count - 1))
				{
					snakeBox = new PictureBox()
					{
						Size = new Size(boxSize, boxSize),
						Location = p,
						Image = Resources.snake_body,
						Name = $"snake-box-{snake.IndexOf(p)}",
						BorderStyle = BorderStyle.None,
					};
					grpbxGameGrid.Controls.Add(snakeBox);
					snakeBox.BringToFront();
				}
			}
		}

		private Point GetStartingPoint()
		{
			int randomBox = random.Next(totalBoxes);
			Control startingBox = grpbxGameGrid.Controls[randomBox];
			return startingBox.Location;
		}

		private void MoveSnake()
		{
			Point head = snake[0];
			Point newHead = head;

			switch (direction)
			{
				case 0: newHead.Y -= boxSize; break; // Up
				case 1: newHead.X += boxSize; break; // Right
				case 2: newHead.Y += boxSize; break; // Down
				case 3: newHead.X -= boxSize; break; // Left
			}

			snake.Insert(0, newHead);

			if (newHead == bait)
			{
				score++;
				CreateBait();
			}
			else
			{
				snake.RemoveAt(snake.Count - 1); // Remove tail to maintain the length
			}
			if (SnakeCollided())
			{
				timerGameLoop.Stop();
				MessageBox.Show("Game over");
				Application.Exit();
			}
			CreateSnake();
		}

		private bool SnakeCollided() {
			bool collided = false;
			Point head = snake[0];
			if (head.X < 0 || head.X > (boxesInRow-1) * boxSize ||
				head.Y < 0 || head.Y > (boxesInColumn - 1) * boxSize ||
				snake.GetRange(1, snake.Count - 1).Contains(head))
			{
				collided = true;
			}
			return collided;
		}

		private void CreateBait()
		{
			do
			{
				bait = grpbxGameGrid.Controls[random.Next(totalBoxes)].Location;
			} while (snake.Contains(bait));
			baitBox.Location = bait;
			baitBox.BringToFront();
		}

		private void timerGameLoop_Tick(object sender, EventArgs e)
		{
			MoveSnake();
			lblHighestScore.Text = $"{snake.Count}";
		}

		private void FormSnakeGame_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Up && direction != 2) direction = 0;
			if (e.KeyCode == Keys.Right && direction != 3) direction = 1;
			if (e.KeyCode == Keys.Down && direction != 0) direction = 2;
			if (e.KeyCode == Keys.Left && direction != 1) direction = 3;
		}
	}
}