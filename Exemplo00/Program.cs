using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplo00
{
    public class Program
    {
        static void Main(string[] args)
        {
            SistemaContext contexto = new SistemaContext();

            #region Inserir
            //Animal animal2 = new Animal();
            //animal2.Nome = "TRex";
            //animal2.Extinto = true;

            //contexto.Animais.Add(animal2);
            //contexto.SaveChanges();
            //Console.WriteLine("Registro salvo Com suscesso");
            #endregion Inserir
            // o comando acima epara inserir nobanco de dados




            #region Apagar
            //Animal AnimalApagar = contexto.Animais.Where(x => x.Nome == "Zebra").First();
            //contexto.Animais.Remove(AnimalApagar);
            //contexto.SaveChanges();
            #endregion
            //comando acima serve para apagar do banco


            #region  Alterar
            //var TRex = contexto.Animais
            //    //.Where()
            //    .First(x => x.Id == 2);
            //TRex.Nome = "Cachoro";
            //contexto.SaveChanges();
            #endregion



            #region Listar
            List<Animal> animais = contexto
                .Animais
                //.Where(x => x.Extinto == true && x.Nome.Contains("T"))
                .OrderBy(x => x.Nome)
                .ToList();
            foreach (Animal animal in animais)
            {
                Console.WriteLine($"{animal.Id} {animal.Nome} - {animal.Extinto} {animal.Peso}");
            }
            #endregion


            //Habilidade habilidade = new Habilidade();
            //habilidade.IdAnimal = 1;
            //habilidade.Nome = "Invisibilidade";

            //contexto.Habilidades.Add(habilidade);
            //contexto.SaveChanges();

            var habilidades = contexto.Habilidades
                .Include("Animal")
                .ToList();

            foreach(Habilidade habilidadeAux in habilidades)
            {
                Console.WriteLine(habilidadeAux.Animal.Nome + "-"+ habilidadeAux.Nome);
            }

        }
    }
}
