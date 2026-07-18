using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Domain
{
    //تی تایپ کلاس است و  اون یکی نوع ایدی
    public interface IRepository<Tkey , T> where T : class
    {
        T Get(long id);//جهت دریافت یک رکورد 
        List<T> Get();//یک لیستی از جدول به ما بر میگرداند 
        void Create(T entity);// برای ایجاد است که تی یا همان کلاس را به انواه انتیتی ورودی از ما میگیرد 
        bool Exists(Expression<Func<T, bool>> expression);//من واقعا این خط را نفهمیدم و از چت هوش مصنوعی گرفتم
        void SaveChanges();

    }
}
