using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.IDomain;
using TicTacToe.IDomain.Dto;
using TicTacToe.IDomain.Events;

namespace TicTacToe.Domain.GameAggregate
{
    public class Game : IGame
    {
        Guid gameId;
        Player[] players;
        Grid grid;
        IDomainEventChannel domainEventChannel;
        int? iCurrentPlayer;

       

        public Game(IDomainEventChannel domainEventChannel, 
                    Guid gameId, 
                    Player[] players, 
                    int? iCurrentPlayer,
                    Grid grid)
        {
            if (domainEventChannel == null) 
                throw new ArgumentNullException("domainEventChannel");

            this.domainEventChannel = domainEventChannel;

            if (gameId == null)
                throw new ArgumentNullException("gameId");

            this.gameId = gameId;
            if (players == null)
                throw new ArgumentNullException("players");

            if (players.GetLength(0) != 2)
                throw new InvalidOperationException(
                    string.Format("invalid players range. Expected : 2. actual : {0}", 
                        players.GetLength(0)));

            this.players = players;

            if (!new int?[] { 0, 1, null }.Contains(iCurrentPlayer))
                throw new InvalidOperationException(
                    string.Format("invalid current player value. Expected : 0, 1 or null. actual : {0}",
                        iCurrentPlayer)
                    );

            this.iCurrentPlayer = iCurrentPlayer;

            this.grid = grid;


        }
        public string GetPlayer1Code()
        {
            return players[0].PlayerCode;
        }

        public string GetPlayer2Code()
        {
            return players[1].PlayerCode;
        }

        public string GetCurrentPlayerCode()
        {
            
            if (iCurrentPlayer.HasValue && 
                new int[] { 0, 1 }.Contains(iCurrentPlayer.Value))
            {
                return players[iCurrentPlayer.Value].PlayerCode;
            }
            else
            {
                return String.Empty;
            }
        }

        private void NextPlayer()
        {
            if (iCurrentPlayer.HasValue)
            {
                iCurrentPlayer = (iCurrentPlayer.Value + 1) % 2;
            }
            else
            {
                iCurrentPlayer = 0;
            }
            
            domainEventChannel.Submit<CurrentPlayerChanged>(
                    new CurrentPlayerChanged(
                        new GameDto(GetCurrentGrid(), GetCurrentPlayerCode())));
        }
        
        public string GetCurrentGrid()
        {
            return grid.ToString();
        }

        public void Start()
        {
            NextPlayer();
        }

        

        public void ApplyPlayerSelection(string playerCode, int x, int y)
        {
            if (playerCode.Equals(GetCurrentPlayerCode()))
            {
                 grid = grid.WithNewPlayerSelection(GetPlayer(playerCode), x, y);

                 NextPlayer();
            }
        }

     

        private Player GetPlayer(string playerCode)
        {
            return players.Where(x => x.PlayerCode == playerCode).First();
               
        }
    }
}
