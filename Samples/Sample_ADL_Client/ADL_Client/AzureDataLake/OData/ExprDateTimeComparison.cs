namespace AzureDataLake.ODataQuery
{
    public class ExprDateTimeComparison : Expr
    {
        public string Column;
        public System.DateTime Value;
        public NumericCompareOps Op;
        public ExprDateTimeComparison(string col, System.DateTime val, NumericCompareOps op)
        {
            this.Column = col;
            this.Value = val;
        }

        public override void ToExprString(System.Text.StringBuilder sb)
        {
            string datestring = this.Value.ToString("O");

            // due to issue: https://github.com/Azure/autorest/issues/975,
            // date time offsets must be explicitly escaped before being passed to the filter

            var escaped_datestring = System.Uri.EscapeDataString(datestring);

            var op = FilterUtils.OpToString(this.Op);
            sb.Append(string.Format("{0} {1} datetimeoffset'{2}'", this.Column, op, escaped_datestring));
        }
    }

    public class IntegerComparison : Expr
    {
        public string Column;
        public int Value;
        public NumericCompareOps Op;
        public IntegerComparison(string col, int val, NumericCompareOps op)
        {
            this.Column = col;
            this.Value = val;
        }

        public override void ToExprString(System.Text.StringBuilder sb)
        {
            string datestring = this.Value.ToString("O");

            // due to issue: https://github.com/Azure/autorest/issues/975,
            // date time offsets must be explicitly escaped before being passed to the filter

            var escaped_datestring = System.Uri.EscapeDataString(datestring);

            var op = FilterUtils.OpToString(this.Op);
            sb.Append(string.Format("{0} {1} {2}", this.Column, op, escaped_datestring));
        }
    }

}