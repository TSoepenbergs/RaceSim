using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Section
    {
        public string[] Graphic { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public enum SectionTypes
        {
            Straight,
            LeftCorner,
            RightCorner,
            StartGrid,
            Finish
        }
        public SectionTypes SectionType { get; set; }
        public Section(SectionTypes sectionType)
        {
            SectionType = sectionType;
        }

/*        public Section()
        {
        }*/
    }
}
