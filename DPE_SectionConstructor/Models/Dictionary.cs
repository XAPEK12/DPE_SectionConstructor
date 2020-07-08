using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPE_SectionConstructor.Models
{
    public static class Dictionary
    {
        public static Dictionary<string, string> DBtoDataGridDictionary = new Dictionary<string, string>
        {
            {"Марка",   "Marka" },
            {"P, кг|м", "P" },
            {"d, см",   "B" },
            {"h, см",   "H" },
            {"b, см",   "B" },
            {"s, см",   "Ts" },
            {"t, см",   "Tf" },
            {"r, см",   "R" },
            {"A, см2",   "A" },
            {"Ix, см4", "Ix" },
            {"Wx, см3", "Wx" },
            {"Sx, см3", "Sx" },
            {"ix, см",  "I0x" },
            {"Iy, см4", "Iy"  },
            {"Wy, см3", "Wy"  },
            {"Sy, см3", "Sy"  },
            {"iy, см",  "I0y" },
            {"It, см4", "It" }
        };

        public static Dictionary<string, string> SectionTypeDictionary = new Dictionary<string, string>
        {
            { "Уголки"                   ,"Уголок"                       },
            { "Швеллеры"                 ,"Швеллер"                      },
            { "Двутавры"                 ,"Двутавр"                      },
            { "Тавры"                    ,"Тавр"                         },
            { "Круглые трубы"            ,"Круглая труба"                },
            { "Квадратные трубы"         ,"Прямоугольная труба"          },
            { "Прямоугольные трубы"      ,"Прямоугольная труба"          },
            { "Гнутые С-образные профили","Гнутый С-образный профиль"    },
            { "Гнутые Z-образные профили","Гнутый Z-образный профиль"    }
        };

    }
}
