using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPE_SectionConstructor.Models
{

    /// <summary>
    /// TreeViev Model для SortamentView
    /// </summary>
    public class TVModel
    {
        public ObservableCollection<TVItem> TVItems { get; private set; }
        public TVModel()
        {
            var Types = new SortamentTypes().Types;

            TVItems = new ObservableCollection<TVItem>
            {
                new TVItem
                {
                    Name = "Уголки",
                    TVItems = new ObservableCollection<TVItem>
                    {
                        new TVItem { Name = Types[0], ParentName = "Уголки" },
                        new TVItem { Name = Types[1], ParentName = "Уголки" }
                    }
                },

                new TVItem
                {
                    Name = "Швеллеры",
                    TVItems = new ObservableCollection<TVItem>
                    {
                        new TVItem { Name = Types[2], ParentName = "Швеллеры"  },
                        new TVItem { Name = Types[3], ParentName = "Швеллеры"  },
                        new TVItem { Name = Types[4], ParentName = "Швеллеры"  },
                        new TVItem { Name = Types[5], ParentName = "Швеллеры"  },
                        new TVItem { Name = Types[6], ParentName = "Швеллеры"  }
                    }
                },

                new TVItem
                {
                    Name = "Двутавры",
                    TVItems = new ObservableCollection<TVItem>
                    {
                        new TVItem { Name = Types[7] , ParentName = "Двутавры" },
                        new TVItem { Name = Types[8] , ParentName = "Двутавры" },
                        new TVItem { Name = Types[9] , ParentName = "Двутавры" },
                        new TVItem { Name = Types[10], ParentName = "Двутавры"  },
                        new TVItem { Name = Types[11], ParentName = "Двутавры"  },
                        new TVItem { Name = Types[12], ParentName = "Двутавры"  },
                        new TVItem { Name = Types[13], ParentName = "Двутавры"  },
                        new TVItem { Name = Types[14], ParentName = "Двутавры"  },
                        new TVItem { Name = Types[15], ParentName = "Двутавры"  },
                        new TVItem { Name = Types[16], ParentName = "Двутавры"  }
                    }
                },

                new TVItem
                {
                    Name = "Тавры",
                    TVItems = new ObservableCollection<TVItem>
                    {
                        new TVItem { Name = Types[17], ParentName = "Тавры" },
                        new TVItem { Name = Types[18], ParentName = "Тавры" },
                        new TVItem { Name = Types[19], ParentName = "Тавры" }
                    }
                },

                new TVItem
                {
                    Name = "Круглые трубы",
                    TVItems = new ObservableCollection<TVItem>
                    {
                        new TVItem { Name = Types[20], ParentName = "Круглые трубы" },
                        new TVItem { Name = Types[21], ParentName = "Круглые трубы" },
                        new TVItem { Name = Types[22], ParentName = "Круглые трубы" }
                    }
                },

                new TVItem
                {
                    Name = "Квадратные трубы",
                    TVItems = new ObservableCollection<TVItem>
                    {
                        new TVItem { Name = Types[23], ParentName = "Квадратные трубы"   },
                        new TVItem { Name = Types[24], ParentName = "Квадратные трубы"   },
                        new TVItem { Name = Types[25], ParentName = "Квадратные трубы"   }
                    }
                },

                new TVItem
                {
                    Name = "Прямоугольные трубы",
                    TVItems = new ObservableCollection<TVItem>
                    {
                        new TVItem { Name = Types[26], ParentName = "Прямоугольные трубы" },
                        new TVItem { Name = Types[27], ParentName = "Прямоугольные трубы" },
                        new TVItem { Name = Types[28], ParentName = "Прямоугольные трубы" }
                    }
                },

                new TVItem
                {
                    Name = "Гнутые С-образные профили",
                    TVItems = new ObservableCollection<TVItem>
                    {
                        new TVItem { Name = Types[29], ParentName = "Гнутые С-образные профили" }
                    }
                },

                new TVItem
                {
                    Name = "Гнутые Z-образные профили",
                    TVItems = new ObservableCollection<TVItem>
                    {
                        new TVItem { Name = Types[30], ParentName = "Гнутые Z-образные профили" },
                        new TVItem { Name = Types[31], ParentName = "Гнутые Z-образные профили" }
                    }
                },



            };
        }
    }
}
