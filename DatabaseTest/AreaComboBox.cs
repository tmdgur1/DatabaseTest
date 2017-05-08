using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTest
{
    class AreaComboBox
    {
        private string project_nm;
        private string module_nm;
        private string deck_cd;

        public AreaComboBox()
        {
            project_nm = "";
            module_nm = "";
            deck_cd = "";
        }

        public string Project_nm
        {
            get
            {
                return project_nm;
            }

            set
            {
                project_nm = value;
            }
        }

        public string Module_nm
        {
            get
            {
                return module_nm;
            }

            set
            {
                module_nm = value;
            }
        }

        public string Deck_cd
        {
            get
            {
                return deck_cd;
            }

            set
            {
                deck_cd = value;
            }
        }
    }
}
