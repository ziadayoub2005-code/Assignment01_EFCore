namespace EFDay01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // introduction
            // Mapping from classes to tables (object mapper)

            //Code first -> Mapping
            //class First

            //ERD  >>  Class Diagram
            //class diagram specs(Self)  >> classes(Relations,annotations)

            //Models - Entities - POCO classes
            // plain old Clr obj
            // container for properties(No functionality/logic)

            // S : Principle : only one Concern
            // Modularity 

            // DbContext

            // * Map from C# to DB
            // 1- define Entity classes >> Models
            // Pkg >> sqlserver
            // 2- Define ur DbContext class >> Connect DB(Connection Data) - Model mapping
            // Execute The Connection(Mapping)
            // Pkg >> migrations >> tools
            // 3- DB Feel this?  No! >> Migration
            // Manage migrations : PM Console
            //   --> Prepare Change : add-migration >> same >> Remove-Migration
            //   --> Apply the change in DB : update-database   >>  unapply change
             // = revert = rollback

            // Migration : Consistency : two layers

            // Unapply changes :
            // 1- Revert    or    New Migration  
            // 2- New Migration
            // Practice : New Migration : Versioning - Maintainabiltity
            


            // Remove tests : Revert / rollback
            // Creage Emps/Tests 
            // Remove tests > rollback
            // Migration with change only !

            // Create Tests 
            // Unapply Tests ?
            // Revert (update DB Previos)   or   New Migration (Recommended)

            // not revert 
            // any change : new Migration >> up >> expressive
            // mig01(1,2,3) - mig02(4,5,6) - mig03(drop 5)

            // * Query object model(Maintain relationships-Perform DB operations)

            //Up to new Change   Vs  Up to previous Change  >>  Self

        }
    }
}
