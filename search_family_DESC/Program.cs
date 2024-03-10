// See https://aka.ms/new-console-template for more information
using search_family_DESC.Model;





List<family> fa = new List<family>
    {
        new family{Id = 1, Name = "Lee" ,DOB = Convert.ToDateTime("7 May 1890")},
        new family{Id = 2, Name = "Robert" ,DOB = Convert.ToDateTime("10 July 1920")},
        new family{Id = 3, Name = "Kris" ,DOB = Convert.ToDateTime("26 December 1944")},

       // new family{Id = 3, Name = "Kawin" ,DOB = Convert.ToDateTime("6 December 1921")},
    };


string input_name = "Kris";
Console.WriteLine("display the seniority from younger to older by input the name : {0} ", input_name);

Show_family_DESC(input_name, fa);


static void Show_family_DESC(string input_name, List<family> fa)
{

    var list_input =
        (from f in fa
         where f.Name == input_name
         select new { f }).ToList();


    var list_fam = (from fam in fa
                    where fam.Id != list_input[0].f.Id
                    orderby fam.DOB descending
                    select new { fam }).ToList();

    var Fist_row = (from la in fa
                    orderby la.DOB ascending
                    select new { la }).ToList().First();


    for (var i = 0; i < list_fam.Count() - 1; i++)
    {

        if (Fist_row.la.Id == list_input[0].f.Id)
        {
            Console.WriteLine("Not Found");

        }
        else
        {
            Console.WriteLine("{0} < {1}", list_fam[i].fam.Name, list_fam[i + 1].fam.Name);
        };

    }

}


Console.ReadLine();