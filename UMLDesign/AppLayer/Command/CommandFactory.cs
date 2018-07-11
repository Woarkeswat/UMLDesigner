using AppLayer.DrawingComponents;

namespace AppLayer.Command
{
    /// <summary>
    /// CommandFactory
    /// 
    /// Creates standard commands, but can be specialized to create custom commands.  This class is the base
    /// class in a factory method pattern.
    /// </summary>
    public class CommandFactory
    {
        private static CommandFactory _instance;
        private static readonly object MyLock = new object();
        private CommandFactory() { }

        public static CommandFactory Instance
        {
            get
            {
                lock (MyLock)
                {
                    if (_instance==null)
                        _instance = new CommandFactory();
                }
                return _instance;
            }
        }

        public Drawing TargetDrawing { get; set; }
        public Invoker Invoker { get; set; }

        public virtual void CreateAndDo(string commandType, params object[] commandParameters)
        {
            if (string.IsNullOrWhiteSpace(commandType)) return;

            if (TargetDrawing == null) return;

            Command command=null;
            switch (commandType.Trim().ToUpper())
            {
                case "NEW":
                    command = new NewCommand();
                    break;
                case "ADDTREE":
                    command = new AddClassDiagramCommand(commandParameters);
                    break;
                case "ADDBOX":
                    command = new AddBoxCommand(commandParameters);
                    break;
                case "ADDLINE":
                    command = new AddLineCommand(commandParameters);
                    break;
                case "REMOVE":
                    command = new RemoveSelectedCommand();
                    break;
                case "SELECT":
                    command = new SelectCommand(commandParameters);
                    break;
                case "DESELECT":
                    command = new DeselectAllCommand();
                    break;
                case "LOAD":
                    command = new LoadCommand(commandParameters);
                    break;
                case "SAVE":
                    command = new SaveCommand(commandParameters);
                    break;
            }

            if (command != null)
            {
                command.TargetDrawing = TargetDrawing;
                Invoker.EnqueueCommandForExecution(command);
            }
        }
    }
}

