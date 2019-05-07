using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrayanTechnicalTest.ENT.DTO
{
    public class DTOTree
    {
        public DTOTree()
        {

        }
        public DTOTree(int value)
        {
            data = value;
            Left = Right = null;
        }
        public int data;
        public DTOTree Left { get; set; }
        public DTOTree Right { get; set; }

       
    }
}
