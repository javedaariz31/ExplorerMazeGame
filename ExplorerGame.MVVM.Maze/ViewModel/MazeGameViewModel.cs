﻿using ExplorerGame.MVVM.Maze.Common;
using ExplorerGame.MVVM.Maze.Model;
using System;
using System.ComponentModel;

namespace ExplorerGame.MVVM.Maze.ViewModel
{
    public class MazeGameViewModel : NotificationBase
    {
        #region Fields
        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public MazeGameViewModel()
        {
            try
            {
                // Initialise the model class.
                Maze = new GameMaze();
                Maze.PropertyChanged += OnMazePropertyChanged;

                // Initialise the commands.
                GenerateMazeCommand = new DelegateCommand(OnGenerateMaze, CanGenerateMaze);
                ResetMazeCommand = new DelegateCommand(OnResetMaze, CanResetMaze);
            }
            catch (Exception ex)
            {
                throw new Exception("MazeGeneratorViewModel(): " + ex.ToString());
            }
        }

        #endregion


        #region Properties

        /// <summary>
        /// Gets the maze model class.
        /// </summary>
        public GameMaze Maze { get; }

        /// <summary>
        /// Gets or sets the generate maze command.
        /// </summary>
        public DelegateCommand GenerateMazeCommand { get; private set; }

        /// <summary>
        /// Gets or sets the reset simulation command.
        /// </summary>
        public DelegateCommand ResetMazeCommand { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// The OnGenerateMaze method is called to generate a new maze.
        /// </summary>
        /// <param name="arg"></param>
        public async void OnGenerateMaze(object arg)
        {
            try
            {
                if (Maze != null)
                {
                    await Maze.GenerateNewMaze();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("MazeGeneratorViewModel.OnGenerateMaze(object arg): " + ex.ToString());
            }
        }

        /// <summary>
        /// The CanGenerateMaze method is callled to determine if a new maze can be generated.
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public bool CanGenerateMaze(object arg)
        {
            return Maze != null && Maze.CanGenerateMaze;
        }

        /// <summary>
        /// The OnResetMaze method is called to reset the simulation.
        /// </summary>
        /// <param name="arg"></param>
        public void OnResetMaze(object arg)
        {
            try
            {
                if (Maze != null)
                {
                    Maze.ResetMaze();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("MazeGeneratorViewModel.OnResetMaze(object arg): " + ex.ToString());
            }
        }

        /// <summary>
        /// The CanResetMaze method is callled to determine if the simulation can be reset.
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public bool CanResetMaze(object arg)
        {
            return Maze != null && Maze.CanResetMaze;
        }

        /// <summary>
        /// The OnMazePropertyChanged method is called when a property in the Maze model class changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMazePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                GenerateMazeCommand.RaiseCanExecuteChanged();
                ResetMazeCommand.RaiseCanExecuteChanged();
            }
            catch (Exception ex)
            {
                throw new Exception("MazeGeneratorViewModel.OnMazePropertyChanged(object sender, PropertyChangedEventArgs e): " + ex.ToString());
            }
        }

        #endregion
    }
}
