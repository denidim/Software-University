namespace TicTakToeVsAI
{
    public class Index
    {
        public Index(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public Index(string str)
        {
            var parts = str.Split(',');
            this.Row = int.Parse(parts[0]);
            this.Col = int.Parse(parts[1]);
        }

        public override bool Equals(object obj)
        {
            var index2 = obj as Index;

            return this.Row == index2.Row && this.Col == index2.Col;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public override string ToString()
        {
            return $"{this.Row}, {this.Col}";
        }
    }
}
