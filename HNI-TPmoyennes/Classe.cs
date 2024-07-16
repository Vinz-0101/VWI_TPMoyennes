using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Classe
    {
        public string nomClasse { get; private set; }
        public List<Eleve> eleves { get; private set; }
        public List<string> matieres { get; private set; }

        public Classe(string nomClasse)
        {
            this.nomClasse = nomClasse;
            this.eleves = new List<Eleve>();
            this.matieres = new List<string>();
        }

        public void ajouterEleve(string prenom, string nom)
        {
            if (eleves.Count < 30)
            {
                eleves.Add(new Eleve(prenom, nom));
            }
            else
            {
                Console.WriteLine("Le nombre maximum d'élève dans la classe est atteint.");
            }
        }

        public void ajouterMatiere(string matiere)
        {
            if (matieres.Count < 10)
            {
                matieres.Add(matiere);
            }
            else
            {
                Console.WriteLine("Le nombre maximum de matières est atteint.");
            }
        }

        public float Moyenne(int matiere)
        {
            float total = 0;
            int count = 0;

            foreach (var eleve in eleves)
            {
                float moyenne = eleve.Moyenne(matiere);
                if (moyenne > 0)
                {
                    total += moyenne;
                    count++;
                }
            }

            return count > 0 ? (float)Math.Truncate(total / count * 100) / 100 : 0;
        }

        public float Moyenne()
        {
            float total = 0;
            int matiereCount = 0;

            for (int i = 0; i < matieres.Count; i++)
            {
                float moyenneMatiere = Moyenne(i);
                if (moyenneMatiere > 0)
                {
                    total += moyenneMatiere;
                    matiereCount++;
                }
            }

            return matiereCount > 0 ? (float)Math.Truncate(total / matiereCount * 100) / 100 : 0;
        }
    }
}
