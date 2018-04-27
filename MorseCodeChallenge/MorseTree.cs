namespace MorseCodeChallenge
{
    class MorseTree
    {
        public MorseTreeNode Root { get; }

        public MorseTree()
        {
            // Tier 0
            Root = new MorseTreeNode(' ');

            // Tier 1
            Root.Dash = new MorseTreeNode('t');
            Root.Dot = new MorseTreeNode('e');

            // Tier 2
            Root.Dash.Dash = new MorseTreeNode('m');
            Root.Dash.Dot = new MorseTreeNode('n');
            Root.Dot.Dash = new MorseTreeNode('a');
            Root.Dot.Dot = new MorseTreeNode('i');

            // Tier 3
            Root.Dash.Dash.Dash = new MorseTreeNode('o');
            Root.Dash.Dash.Dot = new MorseTreeNode('g');
            Root.Dash.Dot.Dash = new MorseTreeNode('k');
            Root.Dash.Dot.Dot = new MorseTreeNode('d');
            Root.Dot.Dash.Dash = new MorseTreeNode('w');
            Root.Dot.Dash.Dot = new MorseTreeNode('r');
            Root.Dot.Dot.Dash = new MorseTreeNode('u');
            Root.Dot.Dot.Dot = new MorseTreeNode('s');

            // Tier 4
            Root.Dash.Dash.Dot.Dash = new MorseTreeNode('q');
            Root.Dash.Dash.Dot.Dot = new MorseTreeNode('z');
            Root.Dash.Dot.Dash.Dash = new MorseTreeNode('y');
            Root.Dash.Dot.Dash.Dot = new MorseTreeNode('c');
            Root.Dash.Dot.Dot.Dash = new MorseTreeNode('x');
            Root.Dash.Dot.Dot.Dot = new MorseTreeNode('b');
            Root.Dot.Dash.Dash.Dash = new MorseTreeNode('j');
            Root.Dot.Dash.Dash.Dot = new MorseTreeNode('p');
            Root.Dot.Dash.Dot.Dot = new MorseTreeNode('l');
            Root.Dot.Dot.Dash.Dot = new MorseTreeNode('f');
            Root.Dot.Dot.Dot.Dash = new MorseTreeNode('v');
            Root.Dot.Dot.Dot.Dot = new MorseTreeNode('h');
        }
    }
}
