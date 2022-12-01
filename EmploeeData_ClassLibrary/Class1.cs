using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploeeData_ClassLibrary
{
    public class Emploee
    {
        #region Поля

        private int? idEmploee = null;
        private DateTime dateOfCreate;
        private string fullName = null;
        private int? age = null;
        private int? heigth = null;
        private DateTime dOB;
        private string placeOfBirth = null;

        #endregion

        #region Свойства

        /// <summary>
        /// ID of Emploee
        /// </summary>
        public int? IdEmploee { get; set; }

        /// <summary>
        /// Date of Create info about emploee
        /// </summary>
        public DateTime DateOfCreate { get; set; }

        /// <summary>
        /// Full name of Emploee
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Age of Emploee
        /// </summary>
        public int? Age { get; set; }

        /// <summary>
        /// Height of Emploee
        /// </summary>
        public int? Heigth { get; set; }

        /// <summary>
        /// Date of Birth
        /// </summary>
        public DateTime DOB { get; set; }

        /// <summary>
        /// PLace where emploee was born
        /// </summary>
        public string PlaceOfBirth { get; set; }

        #endregion

        #region Method

        /// <summary>
        /// This method shows data about emploee
        /// </summary>
        /// <returns></returns>
        public string ShowInfoAboutEmploee()
        {
            return $"{IdEmploee,5} {DateOfCreate,15} {FullName,35} {Age,3} {Heigth,3} {DOB,15} {PlaceOfBirth, 20}";
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for class Emploee
        /// </summary>
        /// <param name="idEmploee">Id of emploee </param>
        /// <param name="dateOfCreate">date of create info about emploee</param>
        /// <param name="fullName">Full name of emploee</param>
        /// <param name="age">age of emploee</param>
        /// <param name="heigth">height of emploee</param>
        /// <param name="dOB">Date of Birth </param>
        /// <param name="placeOfBirth">place where emploee was born</param>
        public Emploee(int? idEmploee, DateTime dateOfCreate, string fullName, int? age, int? heigth, DateTime dOB, string placeOfBirth)
        {
            IdEmploee = idEmploee;
            DateOfCreate = dateOfCreate;
            FullName = fullName;
            Age = age;
            Heigth = heigth;
            DOB = dOB;
            PlaceOfBirth = placeOfBirth;
            IdEmploee = idEmploee;
            DateOfCreate = dateOfCreate;
            FullName = fullName;
            Age = age;
            Heigth = heigth;
            DOB = dOB;
            PlaceOfBirth = placeOfBirth;
        }

        #endregion
    }

}
