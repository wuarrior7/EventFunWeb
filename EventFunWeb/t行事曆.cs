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
    
    public partial class t行事曆
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t行事曆()
        {
            this.t行事曆明細 = new HashSet<t行事曆明細>();
        }
    
        public string f行事曆編號 { get; set; }
        public string f會員編號 { get; set; }
        public string f行事曆名稱 { get; set; }
        public Nullable<System.DateTime> f行事曆建立時間 { get; set; }
    
        public virtual t一般會員 t一般會員 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t行事曆明細> t行事曆明細 { get; set; }
    }
}
