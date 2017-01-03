using static DataModel.Enums;

namespace DataModel
{
    public class TestResult
    {
        public Status Status;
        public string Name;
        public int FailingTime;

        public TestResult()
        {
            Status = Status.None;
            Name = string.Empty;
            FailingTime = 0;
        }

        public bool IsValid()
        {
            return
                Status != Status.None
                && !string.IsNullOrEmpty(Name);
        }
    }
}
