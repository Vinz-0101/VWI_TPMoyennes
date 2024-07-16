using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Eleve
    {
        public string prenom { get; private set; }
        public string nom { get; private set; }
        private List<Note> notes;

        public Eleve(string prenom, string nom)
        {
            this.prenom = prenom;
            this.nom = nom;
            this.notes = new List<Note>();
        }

        public void ajouterNote(Note note)
        {
            if (notes.Count < 200)
            {
                notes.Add(note);
            }
            else
            {
                Console.WriteLine("Le nombre maximum de notes pour l'élève est atteint.");
            }
        }

        public float Moyenne(int matiere)
        {
            float total = 0;
            int count = 0;

            foreach (var note in notes)
            {
                if (note.matiere == matiere)
                {
                    total += note.note;
                    count++;
                }
            }

            return count > 0 ? (float)Math.Truncate(total / count * 100) / 100 : 0;
        }

        public float Moyenne()
        {
            float total = 0;
            int matiereCount = 0;
            List<int> matieresVues = new List<int>();

            foreach (var note in notes)
            {
                if (!matieresVues.Contains(note.matiere))
                {
                    matieresVues.Add(note.matiere);
                    total += Moyenne(note.matiere);
                    matiereCount++;
                }
            }

            return matiereCount > 0 ? (float)Math.Truncate(total / matiereCount * 100) / 100 : 0;
        }
    }
}
