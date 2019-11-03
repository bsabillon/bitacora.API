namespace bitacora.API.Data{
   
    using Microsoft.EntityFrameworkCore;
    using bitacora.API.Models;
    

    public class DataContext: DbContext 
    {
        public DbSet <Category> Categories{get; set;}
        public DbSet <Actividad> Actividades{get; set;}
    
    public DataContext(DbContextOptions<DataContext> options): base(options){
    }

   


    }
}