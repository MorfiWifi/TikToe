using Common.Enums;
using Dto;

namespace Application.Interfaces;

public interface ITickToeHandler
{
    GameStatusEnum GetGameStatus(GameStateDto state1);
}