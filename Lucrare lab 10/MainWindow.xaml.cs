using Lucrare_lab_10.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Lucrare_lab_10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StudentContext db = new StudentContext( );
        public MainWindow( )
        {
            InitializeComponent( );
            List<Student> studentiList = db.Studenti.ToList( );
            studentGrid.ItemsSource = studentiList;
        }

        private void Button2_Click( object sender, RoutedEventArgs e )
        {
            Student s = new Student( );
            s.Nume = numeTxt.Text;
            s.Prenume = prenumeTxt.Text;

            NumberFormatInfo nfi = new NumberFormatInfo( );
            nfi.NumberDecimalSeparator = ".";
            s.Medie = Double.Parse( medieTxt.Text, nfi );

            db.Studenti.Add( s );
            db.SaveChanges( );

            MessageBox.Show( "Student adaugat cu succes!" );
            numeTxt.Text = prenumeTxt.Text = medieTxt.Text = "";

            studentGrid.ItemsSource = db.Studenti.ToList( );
        }

        private void Button_Click( object sender, RoutedEventArgs e )
        {
            Student curentS = (Student)studentGrid.SelectedItem;
            Student s = db.Studenti.Where( c => c.NrMatricol == curentS.NrMatricol ).FirstOrDefault( );
            if(s!=null)
            {
                s = curentS;
                db.SaveChanges( );
                MessageBox.Show( "Datele au fost actualizate cu succes!" );
            }
            studentGrid.ItemsSource = db.Studenti.ToList( );
        }

        private void Button1_Click( object sender, RoutedEventArgs e )
        {
            Student curentS = (Student)studentGrid.SelectedItem;
            Student s = db.Studenti.Where( c => c.NrMatricol == curentS.NrMatricol ).FirstOrDefault( );
            if (s != null)
            {
                db.Studenti.Remove( s );
                db.SaveChanges();
                MessageBox.Show( "Datele au fost sterse cu succes!" );
            }
            studentGrid.ItemsSource = db.Studenti.ToList( );
        }
    }
}
