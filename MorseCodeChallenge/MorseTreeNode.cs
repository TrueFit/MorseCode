namespace MorseCodeChallenge
{
    public class MorseTreeNode
    {

        public MorseTreeNode() { }
        public MorseTreeNode(char character)
        {
            Value = character;
        }

        public char Value { get; set; }
        public MorseTreeNode Dash { get; set; }
        public MorseTreeNode Dot { get; set; }
    }
}
