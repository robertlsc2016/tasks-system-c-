using System.ComponentModel;

namespace TasksSystem.Enums
{
    public enum TaskStatus
    {
        [Description("A Fazer")]
        ToDo = 1,
        
        [Description("Fazendo")]
        Doing = 2,

        [Description("Pronto")]
        Done = 3,
    }
}
