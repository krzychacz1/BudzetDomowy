using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BudzetDomowy
{

    public class BudzetDomowyContext: DbContext
    {
        DbSet<RodzjeTranzakcii> RodzjeTranzakcji { get; set; }
        DbSet<Kategorie> Kategorie { get; set; }
        DbSet<Rozchody> Rozchody { get; set; }
        DbSet<Przychody> Przychody { get; set; }
        DbSet<PlanowaneRozchody> PlanowaneRozchody { get; set; }
        DbSet<PlanowanePrzychody> PlanowanePrzychody { get; set; }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    [Table("RodzjeTranzakcii")]
    public class RodzjeTranzakcii 
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public bool Aktywna { get; set; }
        public DateTime DataDodaniaRekordu { get; set; }
        public Kategorie Kategorie { get; set; }
        [Column(TypeName = "bit")]
        public bool Rodzaj { get; set; }
    }
    [Table("Kategorie")]
    public class Kategorie
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public DateTime DataDodaniaRekordu { get; set; }      

    }
    [Table("Przychody")]
    public class Przychody
    {
        public int Id { get; set; }
        public float Kwota { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataDodaniaRekordu { get; set; }
        public RodzjeTranzakcii RodzjeTranzakcji { get; set; }
    }
   [Table("Rozchody")]
    public class Rozchody 
    {
        public int Id { get; set; }
        public float Kwota { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataDodaniaRekordu { get; set; }
        public RodzjeTranzakcii RodzjeTranzakcji { get; set; }
    }
    [Table("PlanowanePrzychody")]
    public class PlanowanePrzychody
    {
        public int Id { get; set; }
        public float Kwota { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataDodaniaRekordu { get; set; }
        public RodzjeTranzakcii RodzjeTranzakcji { get; set; }
    }
    [Table("PlanowaneRozchody")]
    public class PlanowaneRozchody
    {
        public int Id { get; set; }
        public float Kwota { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataDodaniaRekordu { get; set; }
        public RodzjeTranzakcii RodzjeTranzakcji { get; set; }
    }
}
