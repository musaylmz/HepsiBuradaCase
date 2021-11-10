using MarsRoverCase.Application.Extensions;
using MarsRoverCase.Application.Interfaces;
using MarsRoverCase.ConsoleApp.Helpers;
using MarsRoverCase.Domain.Enums;
using MarsRoverCase.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MarsRoverCase.ConsoleApp
{
    class Program
    {
        static IRoverService _roverService;
        static IPlateauService _plateauService;
        static IDeploymentPositionService _deploymentPositionService;

        static void Main(string[] args)
        {
            var serviceProvider = ServiceProviderHelper.GetServiceProvider();

            _roverService = serviceProvider.GetService<IRoverService>();
            _plateauService = serviceProvider.GetService<IPlateauService>();
            _deploymentPositionService = serviceProvider.GetService<IDeploymentPositionService>();

            Start();
        }

        private static void Start()
        {
            Console.WriteLine("Mars Rover Application");

            var plateau = DrawPlateau();

            var deploymentPosition = DeploymentPosition(plateau);

            var rover = RoverMovement(plateau, deploymentPosition);

            Console.WriteLine($"Rover position: {rover.Position.X} {rover.Position.Y} {rover.Position.Direction}");
        }

        private static Plateau DrawPlateau()
        {
            Console.WriteLine("Enter plateau parameter: (Exp: 5 5)");

            var plateauResponse = _plateauService.DrawPlateau(Console.ReadLine());

            if (!plateauResponse.IsSuccess)
                Exit(plateauResponse.Message);

            return (Plateau)plateauResponse.Data;
        }

        private static Position DeploymentPosition(Plateau plateau)
        {
            Console.WriteLine("Enter rover deployment position of plateau parameter: (Exp: 1 2 N)");

            var deploymentPositionResponse = _deploymentPositionService.SetPosition(plateau, Console.ReadLine());

            if (!deploymentPositionResponse.IsSuccess)
                Exit(deploymentPositionResponse.Message);

            return (Position)deploymentPositionResponse.Data;
        }

        private static Rover RoverMovement(Plateau plateau, Position deploymentPosition)
        {
            Console.WriteLine("Enter rover movement parameter: (Exp: LMLMLMLMM)");

            var roverMovementParams = Console.ReadLine();

            if (!roverMovementParams.CheckMovementParams())
                Exit("Invalid parameters of rover movement");

            var rover = new Rover(deploymentPosition, plateau)
            {
                Movements = roverMovementParams.ToCharArray().Select(x => Enum.Parse<MovementType>(x.ToString())).ToList()
            };

            var roverMovementResponse = _roverService.RoverMovement(rover);

            if (!roverMovementResponse.IsSuccess)
                Exit(roverMovementResponse.Message);

            return (Rover)roverMovementResponse.Data;
        }

        private static void Exit(string message)
        {
            Console.WriteLine(message);
            Environment.Exit(0);
        }
    }
}
