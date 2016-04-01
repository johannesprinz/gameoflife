namespace Thoughtology.GameOfLife.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using Models;

    public class GenerationController : ApiController
    {
        [HttpPost]
        public IEnumerable<Cell> CalculateNextGeneration(IEnumerable<Cell> seed)
        {
            return KillUnderPopulatedCells(seed)
                .Union(KillOverPopulatedCells(seed))
                .Union(ReviveByReproduction(seed))
                .Union(seed);
        }

        private static IEnumerable<Cell> ReviveByReproduction(IEnumerable<Cell> seed)
        {
            return Revive(GetMatingCells(seed));
        }

        private static IEnumerable<Cell> KillUnderPopulatedCells(IEnumerable<Cell> seed)
        {
            return Kill(GetUnderPopulatedCells(seed));
        }

        private static IEnumerable<Cell> KillOverPopulatedCells(IEnumerable<Cell> seed)
        {
            return Kill(GetOverPopulatedCells(seed));
        }

        private static IEnumerable<Cell> GetUnderPopulatedCells(IEnumerable<Cell> cells)
        {
            return cells.Where(cell => cell.Alive && cell.Neighbours < 2);
        }

        private static IEnumerable<Cell> GetOverPopulatedCells(IEnumerable<Cell> cells)
        {
            return cells.Where(cell => cell.Alive && cell.Neighbours > 3);
        }

        private static IEnumerable<Cell> GetMatingCells(IEnumerable<Cell> cells)
        {
            return cells.Where(cell => !cell.Alive && cell.Neighbours == 3);
        }

        private static IEnumerable<Cell> Revive(IEnumerable<Cell> cells)
        {
            foreach (var cell in cells)
            {
                cell.Revive();
                yield return cell;
            }
        }

        private static IEnumerable<Cell> Kill(IEnumerable<Cell> cells)
        {
            foreach (var cell in cells)
            {
                cell.Kill();
                yield return cell;
            }
        }
    }
}
