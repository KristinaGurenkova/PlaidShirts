//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopTest.db
{
    using System;
    using System.Collections.Generic;
    
    public partial class Hall
    {
        public int idHall { get; set; }
        public Nullable<int> idProduct { get; set; }
        public Nullable<int> countProduct { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
