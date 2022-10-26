using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Model.Section;

namespace Model
{
    public class Track
    {
        public string Name { get; set; }
        public LinkedList<Section> Sections { get; set; }
   /*     public LinkedList<Section> toList(SectionTypes[] sections)
        {
            LinkedList<Section> sectionList = new LinkedList<Section>();
            foreach (var sectionType in sections)
            {
                Section section = new Section();
                section.SectionType = sectionType;
                sectionList.AddLast(section);
            }
            return sectionList;
        }*/

 /*       public Section NextSection(Section section)
        {
            bool found = false;
           foreach(Section s in Sections)
            {
                if (found)
                {
                    return s;
                }
                else if (s.Equals(section)) 
                {
                    found = true;
                }
            }
            if (found)
            {
                return Sections.First();
            }
            else
            {
                throw new Exception("No section found");
                return new Section();
            }

            
        }*/
        private LinkedList<Section> GenerateSections(SectionTypes[] sectionTypes)
        {
            LinkedList<Section> sections = new LinkedList<Section>();
            if (sectionTypes == null)
                return sections;
            foreach (SectionTypes sectionType in sectionTypes)
            {
                sections.AddLast(new Section(sectionType));
            }

            return sections;
        }
        public Track(string name, SectionTypes[] sections)
        {
            Name = name;
            Sections = GenerateSections(sections);
        }
    }
}
