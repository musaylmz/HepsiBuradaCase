using MarsRoverCase.Application.Extensions;
using MarsRoverCase.Application.Interfaces;
using MarsRoverCase.ConsoleApp.Helpers;
using MarsRoverCase.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using System;

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

            StartMarsRover();
        }

        private static void StartMarsRover()
        {
            Console.WriteLine("Mars Rover Application Started");

            var plateau = DrawPlateau();

            var deploymentPosition = DeploymentPosition(plateau);

            var rover = MoveRover(plateau, deploymentPosition);

            Console.WriteLine($"Rover move successful. Position: {rover.Position.X} {rover.Position.Y} {rover.Position.Direction}");
        }

        /// <summary>
        /// Konsoldan girilen değere göre platoyu oluşturur.
        /// </summary>
        /// <returns>Plateau model</returns>
        private static PlateauModel DrawPlateau()
        {
            Console.WriteLine("Enter plateau parameter: (Exp: 5 5)");

            var plateauResponse = _plateauService.DrawPlateau(Console.ReadLine());

            if (!plateauResponse.IsSuccess)
                Exit(plateauResponse.Message);

            return (PlateauModel)plateauResponse.Data;
        }

        /// <summary>
        /// Konsoldan girilen değere göre aracın plato üzerine yerleştirilmesini sağlar.
        /// </summary>
        /// <returns>Position model</returns>
        private static PositionModel DeploymentPosition(PlateauModel plateau)
        {
            Console.WriteLine("Enter rover deployment position of plateau parameter: (Exp: 1 2 N)");

            var deploymentPositionResponse = _deploymentPositionService.SetDeploymentPosition(plateau, Console.ReadLine().ToUpper());

            if (!deploymentPositionResponse.IsSuccess)
                Exit(deploymentPositionResponse.Message);

            return (PositionModel)deploymentPositionResponse.Data;
        }

        /// <summary>
        /// Aracın plato üzerinde hareketini gerçekleştirir.
        /// </summary>
        /// <returns>Rover model</returns>
        private static RoverModel MoveRover(PlateauModel plateau, PositionModel deploymentPosition)
        {
            Console.WriteLine("Enter rover movement parameter: (Exp: LMLMLMLMM)");

            var movementTypes = Console.ReadLine().ToUpper().ConvertToMovementTypes();

            if (movementTypes == null)
                Exit("Invalid parameters of rover movement");

            var rover = new RoverModel(deploymentPosition, plateau)
            {
                Movements = movementTypes
            };

            var roverMovementResponse = _roverService.MoveRover(rover);

            if (!roverMovementResponse.IsSuccess)
                Exit(roverMovementResponse.Message);

            return (RoverModel)roverMovementResponse.Data;
        }

        /// <summary>
        /// Hata olması durumunda konsola hata mesajı yazarak, uygulamayı durdurur.
        /// </summary>
        /// <param name="message">Hata mesajı</param>
        private static void Exit(string message)
        {
            Console.WriteLine(message);
            Environment.Exit(0);
        }
    }
}
