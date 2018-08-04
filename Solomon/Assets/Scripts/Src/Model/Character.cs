using System.Collections;
using System.Collections.Generic;
using System.IO;
using Util;

namespace Model {

    public class Character : BaseModel {

        public Character () {
            base.tableName = "export"; 
        }

        public void testFetch () {
            Dictionary<string, string> where = new Dictionary<string, string>();
            where.Add("lank", "1");
            where.Add("type", "1");
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("atk", "9999");
            base.update(where, param);
        }
        
        public void testInsert () {
            Dictionary<string, string> testData = new Dictionary<string, string>();
            testData.Add("id", "99");
            testData.Add("lank", "1");
            testData.Add("name", "テスト");
            testData.Add("type", "1");
            testData.Add("hp", "1");
            testData.Add("atk", "1");
            testData.Add("delete", "1");
            Dictionary<string, string> testData2 = new Dictionary<string, string>();
            testData2.Add("id", "99");
            testData2.Add("lank", "1");
            testData2.Add("name", "テスト2");
            testData2.Add("type", "1");
            testData2.Add("hp", "1");
            testData2.Add("atk", "1");
            testData2.Add("delete", "1");
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
            list.Add(testData);
            list.Add(testData2);
            base.insert(list);
        }
        
        public void testDelete () {
            Dictionary<string, string> where = new Dictionary<string, string>();
            where.Add("lank", "1");
            where.Add("id", "99");
            base.delete(where);
        }
    }
}