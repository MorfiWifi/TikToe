using Application.Interfaces;
using Application.MapperProfile;
using Common.Enums;
using Data.Interfaces;
using Domain;
using Dto.Game;
using Dto.Game.Game;
using Microsoft.EntityFrameworkCore;
using Action = Domain.Action;

namespace Application.Services;

public class GameService(
    ITickToeHandler tickToeHandler,
    IGameRepository gameRepository,
    IActionRepository actionRepository
) : IGameService
{
    //todo: Implement Twos player mod!
    
    
    public GameStateDto PlayAction(Guid gameId, PlayActionDto action)
    {
        if (action.Username is null)
            throw new ExceptionDto("username doesn't exist");

        var game = gameRepository.GetDbSet()
            .FirstOrDefault(x =>
                (x.OPlayer == action.Username || x.XPlayer == action.Username) &&
                x.Id == gameId);

        if (game is null)
            throw new ExceptionDto("Game not found");
        
        if (game.EndedAt is not null)
            throw new ExceptionDto("Game has already ended");

        var charIndex = action.Y * 3 + action.X;
        if (charIndex >= 9 || game.Board[charIndex] != ' ')
            throw new ExceptionDto("Invalid action cant play this");

        var arrayChar = game.Board.ToCharArray();

        if (game.OPlayer == action.Username)
            arrayChar[charIndex] = 'o';
        if (game.XPlayer == action.Username)
            arrayChar[charIndex] = 'x';

        var persistedAction = new Action()
        {
            Id = Guid.NewGuid(),
            X = action.X,
            Y = action.Y,
            Username = action.Username,
            Character = arrayChar[charIndex],
            CratedAt = DateTime.Now,
            GameStatusId = gameId
        };

        actionRepository.GetDbSet().Add(persistedAction);

        game.Board = new string(arrayChar);
        
        //todo: this section applies only for single player 
        PlayNextMoveAsPlayer('o', "system" , game);
        
        var result = Mapper.ToGameStateDto(game, tickToeHandler);
        if (result.Status != GameStatusEnum.ShouldContinue)
            game.EndedAt = DateTime.Now;

        gameRepository.SaveChanges();
        
        return result;
    }

    public GameStateDto JoinGameById(Guid gameId, RequestDto request)
    {
        if (string.IsNullOrEmpty(request.Username))
            throw new ExceptionDto("user is required");

        var game = gameRepository.GetDbSet()
            .FirstOrDefault(x =>
                (x.OPlayer == request.Username || x.XPlayer == request.Username || x.XPlayer == "" ||
                 x.OPlayer == "") &&
                x.Id == gameId);

        if (game is null)
            throw new ExceptionDto("Game not found or other playing");

        if (game.OPlayer == "")
            game.OPlayer = request.Username;

        if (game.XPlayer == "")
            game.XPlayer = request.Username;

        gameRepository.SaveChanges();

        var result = Mapper.ToGameStateDto(game, tickToeHandler);
        return result;
    }

    public GameStateDto FindGameById(Guid gameId, RequestDto request)
    {
        if (string.IsNullOrEmpty(request.Username))
            throw new ExceptionDto("user is required");

        var game = gameRepository.GetDbSet()
            .FirstOrDefault(x =>
                (x.OPlayer == request.Username || x.XPlayer == request.Username) &&
                x.Id == gameId);

        if (game is null)
            throw new ExceptionDto("Game not found or other playing");

        var result = Mapper.ToGameStateDto(game, tickToeHandler);
        return result;
    }

    public GameStateDto CreateNewGame(RequestDto request)
    {
        if (string.IsNullOrEmpty(request.Username))
            throw new ExceptionDto("user is required");

        var game = new GameStatus
        {
            XPlayer = request.Username,
            Turn = 'x',
            CreatedAt = DateTime.Now,
            Id = Guid.NewGuid(),
        };
        
        gameRepository.GetDbSet().Add(game);

        gameRepository.SaveChanges();

        var result = Mapper.ToGameStateDto(game, tickToeHandler);
        return result;
    }

    public PagedResponseDto<GameStateDto> SearchHistory(SearchRequestDto search)
    {
        if (string.IsNullOrEmpty(search.Username))
            throw new ExceptionDto("user is required");

        //todo: apply search params
        search.PageSize = search.PageSize > 100 ? 100 : search.PageSize;

        var query = gameRepository.GetDbSet()
            .Where(x => (x.OPlayer == search.Username || x.XPlayer == search.Username))
            .AsNoTracking();

        var total = query.Count();

        var games = query
            .Skip((search.Page - 1) * search.PageSize)
            .Take(search.PageSize)
            .ToList()
            .Select(x => Mapper.ToGameStateDto(x, tickToeHandler));

        var result = new PagedResponseDto<GameStateDto>
        {
            Page = search.Page,
            PageSize = search.PageSize,
            Data = games.ToList(),
            TotalCount = total,
            IsOk = true,
            Code = 200
        };

        return result;
    }


    private void PlayNextMoveAsPlayer(char player, string username, GameStatus game)
    {
       var gameModel = Mapper.ToGameStateDto(game, tickToeHandler);
       var status = tickToeHandler.GetGameStatus(gameModel.Cells);
       
       //game already finished
       if (status is not GameStatusEnum.ShouldContinue)
           return;
       
       var (col,row) = tickToeHandler.FindNextMove(gameModel.Cells);
       var index = col * 3 + row;
       var boardCharArray = game.Board.ToCharArray();
       boardCharArray[index] = player;
       
       game.Board = new string(boardCharArray);
       
       var persistedAction = new Action()
       {
           Id = Guid.NewGuid(),
           X = col,
           Y = row,
           Username = username,
           Character = player,
           CratedAt = DateTime.Now,
           GameStatusId = game.Id
       };

       actionRepository.GetDbSet().Add(persistedAction);
    }
}