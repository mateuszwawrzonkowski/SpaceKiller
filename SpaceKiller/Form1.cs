using Space_Killer.GameDataDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Space_Killer.GameDataDataSet;

namespace Space_Killer
{
    public partial class SpaceKillerGame : Form
    {
        Stars Stars;
        Ship Spaceship;
        LifeBar LifeBar;
        Button StartButton, SaveScoreButton;
        TextBox PlayerNameTextBox;
        PictureBox[] Enemies;
        PictureBox[] Lasers;

        int Score;
        int PlayerHealth;
        int LaserSpeed;
        int EnemiesSpeed;
        int EnemyLocationX;
        int EnemyLocationY;
        int backgroundSpeed;
        int damage;
        bool gameIsOver;
        bool gameMenu;
        bool lifeBarVisible;
        string PlayerName;

        Random rnd;


        public SpaceKillerGame()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rnd = new Random();
            //Init variables
            Score = 0;
            gameIsOver = false;
            gameMenu = true;
            PlayerName = "Player name";
            LaserSpeed = 15;
            EnemiesSpeed = 3;
            EnemyLocationX = 0;
            EnemyLocationY = 0;
            PlayerHealth = 100;
            lifeBarVisible = false;
            backgroundSpeed = 2;
            damage = 25;
            //Stars
            Stars = new Stars(backgroundSpeed);

            //Spaceship
            Spaceship = new Ship(@".\Resources\spaceship.png")
            {
                spaceshipV = 0,
                spaceshipX = 280,
                spaceshipY = 360,
            };

            //LifeBar
            LifeBar = new LifeBar()
            {
                Health = PlayerHealth,
            };

            //Score
            Score_label.Text = "SCORE: " + Score;


            //Menu
            GameMenu();

            //Laser Player

            Lasers = new PictureBox[3];
            Image Laser = Image.FromFile(@".\Resources\laser.png");

            for (int i = 0; i < Lasers.Length; i++)
            {
                Lasers[i] = new PictureBox();
                Lasers[i].Size = new Size(4, 52);
                Lasers[i].Location = new Point((int)Spaceship.spaceshipX+14, (int)Spaceship.spaceshipY);
                Lasers[i].Image = Laser;

                this.Controls.Add(Lasers[i]);
            }

            //Enemies
            Enemies = new PictureBox[3];
            Image Enemy = Image.FromFile(@".\Resources\enemy1.png");

            for (int i = 0; i < Enemies.Length; i++)
            {
                EnemyLocationX = rnd.Next(20, 480);
                EnemyLocationY = rnd.Next(-600, -121);

                Enemies[i] = new PictureBox();
                Enemies[i].Size = new Size(41, 61);
                Enemies[i].Location = new Point(EnemyLocationX, EnemyLocationY);
                Enemies[i].Image = Enemy;
                Enemies[i].BackColor= Color.Black;
                this.Controls.Add(Enemies[i]);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Stars.Draw(e.Graphics);
            Spaceship.Draw(e.Graphics);
            if (lifeBarVisible == true)
            {
                LifeBar.Draw(e.Graphics);
            }  
        }

        private void MoveBgTimer_Tick(object sender, EventArgs e)
        {

            Stars.BackgroundMoving();
            Score_label.Text = "SCORE: " + Score;
            PlayerNameLabel.Text = "PLAYER: " + PlayerName;
            Invalidate();
        }

        private void LeftMoveTimer_Tick(object sender, EventArgs e)
        {
            Spaceship.Move(0.2f);
            Spaceship.spaceshipV = -20;
        }

        private void RightMoveTimer_Tick(object sender, EventArgs e)
        {
            Spaceship.Move(0.2f);
            Spaceship.spaceshipV = 20;
        }

        private void LaserTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Lasers.Length; i++)
            {
                if (Lasers[i].Top > 0)
                {
                    Lasers[i].Visible = true;
                    Lasers[i].Top -= LaserSpeed;
                    LaserColisionWithEnemies();             
                }
                else
                {
                    Lasers[i].Visible = false;
                    Lasers[i].Location = new Point((int)Spaceship.spaceshipX + 10, (int)Spaceship.spaceshipY);  
                }
            }
        }

        private void EnemiesTimer_Tick(object sender, EventArgs e)
        {

            for (int i = 0; i < Enemies.Length; i++)
            {
                if (Enemies[i].Top < 480)
                {
                    Enemies[i].Visible = true;
                    Enemies[i].Top += EnemiesSpeed;
                }
                else
                {
                    Enemies[i].Visible = false;
                    Enemies[i].Location = new Point(rnd.Next(20, 480), rnd.Next(-500, -121));
                    Score--;
                    LifeBar.Health -= damage;
                }
            }

            if(LifeBar.Health <= 0)
            { 
                GameOver(); 
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if (Spaceship.spaceshipX > 20)
                {
                    LeftMoveTimer.Start();
                }
                else
                {
                    LeftMoveTimer.Stop();
                    Spaceship.spaceshipV = 0;
                }
            }
            if (e.KeyCode == Keys.Right)
            {
                if (Spaceship.spaceshipX < 580)
                {
                    RightMoveTimer.Start();
                }
                else
                {
                    RightMoveTimer.Stop();
                    Spaceship.spaceshipV = 0;
                }
            }

            if (e.KeyCode == Keys.Space)
            {
                LaserTimer.Start();
            }

            if (e.KeyCode == Keys.R)
            {
                ResetGame();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            RightMoveTimer.Stop();
            LeftMoveTimer.Stop();
            Spaceship.spaceshipV = 0;
        }

        private void ResetGame()
        {
            for (int i = 0; i < Enemies.Length; i++)
            {
                Enemies[i].Location = new Point(rnd.Next(20, 480), rnd.Next(-500, -121));
            }
            for (int i = 0; i < Lasers.Length; i++)
            {
                Lasers[i].Visible = false;
                /*Lasers[i].Location = new Point((int)Spaceship.spaceshipX + 10, (int)Spaceship.spaceshipY);*/
            }
          
            Spaceship.spaceshipV = 0;
            Spaceship.spaceshipX = 280;
            Spaceship.spaceshipY = 360;
            LifeBar.Health = PlayerHealth;
            lifeBarVisible = true;
        }

        private void GameOver()
        {
            SaveScoreButton = new Button
            {
                Name = "SaveButton",
                Text = "Save score",
                Size = new Size(124, 45),
                Location = new Point(237, 331),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                Font = new Font(Font.FontFamily, 12),
            };
            SaveScoreButton.Click += SaveScoreBtn;
            this.Controls.Add(SaveScoreButton);
            ResetGame();           
            GameMenu();
            StopTimers();
        }

        private void GameMenu()
        {
            if (gameMenu)
            {
                //Start Button
                StartButton = new Button
                {
                    Name = "StartButton",
                    Text = "START GAME",
                    Size = new Size(150, 30),
                    Location = new Point(230, 200),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.Transparent,
                    ForeColor = Color.White,
                    Font = new Font(Font.FontFamily, 12),
                };
                StartButton.Click += StartGame;
                this.Controls.Add(StartButton);

                //Player Name Label
                PlayerNameTextBox = new TextBox
                {
                    Name = "PlayerNameTextBox",
                    Text = PlayerName,
                    Size = new Size(150, 100),
                    Location = new Point(230, 57),
                    BackColor = Color.Black,
                    ForeColor= Color.White,
                    TextAlign= HorizontalAlignment.Center,
                    Font = new Font (Font.FontFamily,12),
                };
                this.Controls.Add(PlayerNameTextBox);
                Spaceship.spaceshipY = 480;
                lifeBarVisible = false;
                StopTimers();         
            }

        }

        private void LaserColisionWithEnemies()
        {
            for (int i = 0; i < Enemies.Length; i++)
            {
                if (Lasers[0].Bounds.IntersectsWith(Enemies[i].Bounds) || Lasers[1].Bounds.IntersectsWith(Enemies[i].Bounds) || Lasers[2].Bounds.IntersectsWith(Enemies[i].Bounds))
                {
                    Enemies[i].Visible = false;
                    Enemies[i].Location = new Point(rnd.Next(20, 480), rnd.Next(-500, -121));
                    Score += 1;
                }
            }

        }
        private void StartGame(object sender, EventArgs e)
        {
            PlayerName = PlayerNameTextBox.Text;
            this.Controls.Remove(StartButton);
            this.Controls.Remove(PlayerNameTextBox);
            this.Controls.Remove(SaveScoreButton);
            gameIsOver = false;
            Score = 0;
            ResetGame();
            StartTimers();     
        }

        private void StopTimers()
        {
            LeftMoveTimer.Stop();
            RightMoveTimer.Stop();
            LaserTimer.Stop();
            EnemiesTimer.Stop();
        }
        private void StartTimers()
        {
            LeftMoveTimer.Start();
            RightMoveTimer.Start();
            LaserTimer.Start();
            EnemiesTimer.Start();
        }

        private void SaveScoreBtn(object sender, EventArgs e)
        {

            PlayersScoreTableAdapter saveScores = new PlayersScoreTableAdapter();
            saveScores.Insert(PlayerNameTextBox.Text, Score);
            /*
            GameDataEntities1 gameData = new GameDataEntities1();

            PlayersScore player = new PlayersScore();
            player.PlayerName = PlayerNameTextBox.Text;
            player.Score = Score;

            gameData.PlayersScore.Add(player);
            gameData.SaveChanges();*/
        }

    }
}
