//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace EventFunWeb
{
    using System;
    using System.Collections.Generic;
    
    public partial class t次主題類型
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t次主題類型()
        {
            this.t活動 = new HashSet<t活動>();
            this.t會員喜愛次主題 = new HashSet<t會員喜愛次主題>();
        }
    
        public string f次主題編號 { get; set; }
        public string f主題編號 { get; set; }
        public string f次主題名稱 { get; set; }
    
        public virtual t主題類型 t主題類型 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t活動> t活動 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t會員喜愛次主題> t會員喜愛次主題 { get; set; }
    }
}
