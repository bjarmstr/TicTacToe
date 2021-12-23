using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models.Entities;
using TicTacToe.Models.ViewModels;
using TicTacToe.Repositories.Repositories.Interfaces;
using TicTacToe.Services.Interfaces;
using TicTacToe.Shared.Exceptions;

namespace TicTacToe.Services
{
    public class GameService: IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IPlayerRepository _playerRepository;

        public GameService(IGameRepository gameRepository, IPlayerRepository playerRepository)
        {
            _gameRepository = gameRepository;
            _playerRepository = playerRepository;
        }
        public async Task<GameVM> Create(GameCreateVM src)
        {
            var newEntity = new Game(src);
            newEntity.CreatedDate = DateTime.UtcNow;

            //Initialize the board with default value
            //9 is greater than any possible combination of 1 & 2
            newEntity.Gameboard = new List<int>{
                                9,9,9,
                                9,9,9,
                                9,9,9};

            //Check players are in the system
            await _playerRepository.Verify(src.PlayerIds);
           
            var result = await _gameRepository.Create(newEntity);

            var model = new GameVM(result);
            return model;

        }

        public async Task<MoveVM> Move(MoveCreateVM data)
        {
            //get game from db
            var result = await _gameRepository.Get(data.GameId);

            //whose turn is it?
            bool startPlayersTurn = isStartPlayersTurn(result.Gameboard);


            //is it the entered player's turn?
            int whoseTurn = isPlayersTurn(result, data.Player, startPlayersTurn);
          
            //is the square empty
            if (result.Gameboard[data.Location]!=9)
            {
                throw new NotFoundException("invalid location for move");
            }

            //add turn to gameboard
            result.Gameboard[data.Location] = whoseTurn;

            bool gameOver = false;
            //is there a winner
            bool win = isWinningTurn(result.Gameboard, whoseTurn);

            //was that the last free square or there is a winner
            if (!result.Gameboard.Contains(9) || win == true)
            {
                gameOver = true;

                if (startPlayersTurn) 
                { 
                    result.Winner = result.StartPlayer; 
                }
                else
                {
                    var gp = result.GamePlayers.Where(gp => gp.PlayerId != result.StartPlayer).First();
                    result.Winner = gp.PlayerId;
                }
            }

            //save game move and Winner(if game won) to db
           

            


            //TODO variables to return**
            var model = new MoveVM();
            return model;

        }

        private bool isStartPlayersTurn(List<int> gameboard)
        {
            //count how many turns each player has had
            int x = gameboard.Count(x => x == 1);
            int o = gameboard.Count(o => o == 2);
            if (x == o) return true;
            return false;
        }

        private int isPlayersTurn(Game game, Guid player, bool startersTurn)
        {
            //is this player in this game?
            if (game.GamePlayers.FirstOrDefault(i => i.PlayerId == player) == null)
            {
                throw new NotFoundException("The requested player is not found");
            }
            //is this the start player and is it their turn?
            if (game.StartPlayer == player)
            {   if (startersTurn == false) throw new NotFoundException("Not requested players turn");
                else return 1;
            }
            //or it is this the other player
            if  (startersTurn == true) throw new NotFoundException("Not requested players turn");
            return 2;    
        }

        private bool isWinningTurn(List<int> gameboard, int whoseTurn)
        {
            int winningValue = whoseTurn * 3;
            //horizontal win
            if (gameboard[0] + gameboard[1] + gameboard[2] == winningValue) return true;
            if (gameboard[3] + gameboard[4] + gameboard[5] == winningValue) return true;
            if (gameboard[6] + gameboard[7] + gameboard[8] == winningValue) return true;
            //vertical win
            if (gameboard[0] + gameboard[3] + gameboard[6] == winningValue) return true;
            if (gameboard[1] + gameboard[4] + gameboard[7] == winningValue) return true;
            if (gameboard[2] + gameboard[5] + gameboard[8] == winningValue) return true;
            //diagonal win
            if (gameboard[0] + gameboard[4] + gameboard[8] == winningValue) return true;
            if (gameboard[2] + gameboard[4] + gameboard[6] == winningValue) return true;
            return false;
        }
       

    }
}
