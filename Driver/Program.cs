namespace Driver
{
    class Program
    {
        private static readonly int PrintTenTenBegin = 50;
        private static readonly int MainBegin = 0;

        static void Main(string[] args)
        {
            var computer = Computer.Computer.New(100);

            computer.SetAddress(PrintTenTenBegin)
                .Insert(Computer.InstructionType.Mult)
                .Insert(Computer.InstructionType.Print)
                .Insert(Computer.InstructionType.Ret);

            computer.SetAddress(MainBegin)
                .Insert(Computer.InstructionType.Push, 1009)
                .Insert(Computer.InstructionType.Print);

            computer.Insert(Computer.InstructionType.Push, 6);

            computer.Insert(Computer.InstructionType.Push, 101)
                .Insert(Computer.InstructionType.Push, 10)
                .Insert(Computer.InstructionType.Call, PrintTenTenBegin);

            computer.Insert(Computer.InstructionType.Stop);

            computer.SetAddress(MainBegin)
                .Execute();
        }
    }
}
