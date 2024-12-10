using Application.Interfaces;
using Dto;
using Dto.Game;
using RestApi.Interfaces;

namespace RestApi.Endpoints.Game;

public class GameEndpoints : IEndpointRoute
{
    public void RegisterRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("MyGames/{username:alpha}", (string username, IGameService gameService) => { Results.Ok(); });

        app.MapPost("PlayAction/{gameId:guid}", (IGameService gameService ,Guid gameId, PlayActionDto action) =>
            {
                //todo: make services Async ! 

                if (action.Username is null)
                    throw new ExceptionDto("Invalid User Trying To Play Action");

                var couldFindGame = gameService.GameExists(gameId, action.Username);

                if (couldFindGame is false)
                    throw new ExceptionDto("Game not found");

                var actionResult = gameService.PlayAction(gameId, action);

                var result = new ResponseDto<ActionResponseDto>()
                {
                    Data = actionResult,
                    IsOk = true,
                    Code = 200
                };


                Results.Ok(result);
            })
            .WithName("PlayAction")
            .WithOpenApi();
    }
}