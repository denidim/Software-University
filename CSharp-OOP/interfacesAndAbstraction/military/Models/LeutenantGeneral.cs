using System;
using System.Collections.Generic;
using System.Text;
using military.Interfaces;

namespace military.Models
{
    public class LieutenantGeneral : Private ,ILieutenantGeneral
    {
        public LieutenantGeneral(
            int id,
            string firstName,
            string lastName,
            decimal salary)
            : base(id, firstName, lastName, salary)
        {
            Privates = new List<IPrivate>();
        }

        public ICollection<IPrivate> Privates { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{base.ToString()}");

            sb.AppendLine("Privates:");

            foreach (var item in Privates)
            {
                sb.AppendLine($"  {item}");

            }
            return sb.ToString().TrimEnd();
        }
    }
}
