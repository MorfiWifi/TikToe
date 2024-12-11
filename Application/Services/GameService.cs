using Application.Interfaces;
using Application.MapperProfile;
using Data.Interfaces;
using Dto.Game;
using Dto.Game.Game;

namespace Application.Services;

public class GameService(ITickToeHandler tickToeHandler, IGameRepository gameRepository) : IGameService
{
    public GameStateDto PlayAction(Guid gameId, PlayActionDto action)
    {
        var game = gameRepository.GetDbSet()
            .FirstOrDefault(x =>
                (x.OPlayer == action.Username || x.XPlayer == action.Username) &&
                x.Id == gameId);

        if (game is null)
            throw new ExceptionDto("Game not found");

        var charIndex = action.Y * 3 + action.X;
        if (charIndex >= 9 || game.Board[charIndex] != ' ')
            throw new ExceptionDto("Invalid action cant play this");

        var arrayChar = game.Board.ToCharArray();

        if (game.OPlayer == action.Username)
            arrayChar[charIndex] = 'o';
        if (game.XPlayer == action.Username)
            arrayChar[charIndex] = 'x';

        game.Board = new string(arrayChar);

        gameRepository.SaveChanges();

        var result = Mapper.ToGameStateDto(game, tickToeHandler);
        return result;
    }

    public GameStateDto JoinGameById(Guid gameId, RequestDto request)
    {
        throw new NotImplementedException();
    }

    public GameStateDto FindGameById(Guid gameId, RequestDto request)
    {
        throw new NotImplementedException();
    }

    public GameStateDto CreateNewGame(RequestDto request)
    {
        throw new NotImplementedException();
    }

    public PagedResponseDto<GameStateDto> SearchHistory(SearchRequestDto search)
    {
        throw new NotImplementedException();
    }
}