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
    
    public partial class Concert_Shedule
    {
        public int Id_Shedule { get; set; }
        public Nullable<int> Id_Artist { get; set; }
        public Nullable<int> Id_Perfomance { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.TimeSpan> Time { get; set; }
    
        public virtual Artist Artist { get; set; }
        public virtual Perfomance Perfomance { get; set; }
    }
}
