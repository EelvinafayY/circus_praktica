//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace circus_praktica.DBConnection
{
    using System;
    using System.Collections.Generic;
    
    public partial class Task
    {
        public int IDTask { get; set; }
        public Nullable<int> IDAdmin { get; set; }
        public Nullable<int> IDWorker { get; set; }
        public string Description { get; set; }
        public Nullable<bool> Done { get; set; }
        public string Comment { get; set; }
        public Nullable<bool> Viewed { get; set; }
    
        public virtual Admin Admin { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
