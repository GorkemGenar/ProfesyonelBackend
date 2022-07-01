using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfesyonelBackend.Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        //İlgili datanın unique Id sine göre cache den getir.
        T Get<T>(string key);
        
        //Cache e yeni data ekle (unique key, data ve cache zamanı ile birlikte)
        void Add(string key, object data, int cachetime);

        //Cache listesinde belirtilen unique keyde data var mı
        bool IsAdd(string key);

        //Belirtilen unique id deki datayı cache listesinden sil
        void Remove(string key);

        //belirtilen patterne göre cache listesinden sil
        void RemoveByPattern(string pattern);

        //Cache listesini boşalt
        void Clear();
    }
}
