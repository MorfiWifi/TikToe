using Application.Interfaces;
using Dto.Game;
using Dto.Game.Game;
using RestApi.Interfaces;

namespace RestApi.Endpoints.Game;

public class GameEndpoints : IEndpointRoute
{
    public void RegisterRoute(IEndpointRouteBuilder app)
    {
        var apiV1 = app.MapGroup("api/v1/");
        var gameRoute = apiV1.MapGroup("Games/");


        gameRoute.MapPost("JoinGame/{gameId:guid}", (IGameService gameService, Guid gameId, RequestDto request) =>
        {
            var game = gameService.JoinGameById(gameId, request);

            var result = new ResponseDto<GameStateDto> { Data = game, Code = 200, IsOk = true };

            return Results.Ok(result);
        });

        gameRoute.MapPost("GetGame/{gameId:guid}", (IGameService gameService, Guid gameId, RequestDto request) =>
        {
            var game = gameService.FindGameById(gameId, request);

            var result = new ResponseDto<GameStateDto> { Data = game, Code = 200, IsOk = true };
            
            return Results.Ok(result);
        });

        gameRoute.MapPost("CreateGame", (IGameService gameService, RequestDto request) =>
        {
            var result = gameService.CreateNewGame(request);

            return Results.Ok(result);
        });

        gameRoute.MapPost("MyGames", (IGameService gameService, SearchRequestDto search) =>
        {
            var history = gameService.SearchHistory(search);

            return Results.Ok(history);
        });

        gameRoute.MapPost("PlayAction/{gameId:guid}", (IGameService gameService, Guid gameId, PlayActionDto action) =>
        {
            //todo: make services Async ! 

            if (action.Username is null)
                throw new ExceptionDto("Invalid User Trying To Play Action");

            var actionResult = gameService.PlayAction(gameId, action);

            var result = new ResponseDto<GameStateDto>()
            {
                Data = actionResult,
                IsOk = true,
                Code = 200
            };


            return Results.Ok(result);
        });
    }
}