using System;
using System.Data.Common;
using System.Linq;
using Dommel;
using Xunit;

namespace Test
{
    public class DommelTest
    {
        static DommelTest()
        {
            DommelMapper.Resolvers.SetTableNameResolver(new CustomTableNameResolver());
        }
        DbConnection GetConnection()
        {
            const string mysql = "server=172.16.20.90;database=test;uid=root;pwd=1234;charset='utf8'";
            return new MySql.Data.MySqlClient.MySqlConnection(mysql);
        }

        [Fact]
        public void SelectSingle()
        {
            using (var conn = GetConnection())
            {
               var p= conn.Get<Person>(1);
                Assert.True(p?.Id==1);
            }
        }

        [Fact]
        public void SelectAll()
        {
            using (var conn = GetConnection())
            {
                var pList = conn.GetAll<Person>();
                Assert.True(pList.Any());
            }
        }

        [Fact]
        public void SelectWhere()
        {
            using (var conn = GetConnection())
            {
                var p = conn.Select<Person>(a=>a.Id==2);
                Assert.True(p.Any(a=>a.Id==2));
            }
        }


        [Fact]
        public void SelectJoin()
        {
            using (var conn = GetConnection())
            {
                var p = conn.Get< Company,Person, Company>(3, (c, person) => c);
                Assert.True(p.Id==3);
            }
        }

        [Fact]
        public void InsertSingle()
        {
            using (var conn = GetConnection())
            {
                var p = new Person
                {
                    Name = "yc"
                };
                p.Id = Convert.ToInt32(conn.Insert(p));
                Assert.True(p.Id>0);
            }
        }

        [Fact]
        public void UpdateSingle()
        {
            using (var conn = GetConnection())
            {
                var p = new Person
                {
                    Id=1,
                    Name = "ycccccccccccc"
                };
                Assert.True(conn.Update(p));
            }
        }

        [Fact]
        public void InsertWithTransaction()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                var tran = conn.BeginTransaction();
                
                var c = new Company()
                {
                    Name = "yunkai"
                };
               
                c.Id = Convert.ToInt32(conn.Insert(c, tran));
                var p = new Person
                {
                    Name = "chao",
                    CompanyId = c.Id
                };
                p.Id = Convert.ToInt32(conn.Insert(p, tran));
                tran.Commit();
                Assert.True(p.Id>0);

            }
        }
    }

    class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CompanyId { get; set; }
    }

    class Company
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
