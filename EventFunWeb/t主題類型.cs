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
    
    public partial class t主題類型
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t主題類型()
        {
            this.t次主題類型 = new HashSet<t次主題類型>();
        }
    
        public string f主題編號 { get; set; }
        public string f主題名稱 { get; set; }
        public Nullable<bool> f主題狀態 { get; set; }
        public Nullable<int> f主題優先度 { get; set; }
        public Nullable<int> f在線人數 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t次主題類型> t次主題類型 { get; set; }
    }
}
