namespace Thoughtology.GameOfLife.Tests.Web.Models.CellTests
{
    using Foundation;
    using GameOfLife.Web.Models;
    using Machine.Specifications;

    [Subject(typeof(Cell))]
    public class When_reviving_a_dead_cell : WithSubject<Cell>
    {
        Establish context = () =>
        {
            Subject = new Cell(alive: false);
        };

        Because of = () =>
            Subject.Revive();

        It should_mark_the_cell_as_dead = () =>
            Subject.Alive.ShouldBeTrue();
    }
}
