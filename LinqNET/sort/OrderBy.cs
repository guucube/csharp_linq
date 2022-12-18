using System;
using System.Linq;
using Newtonsoft.Json;

namespace LinqNET.sort
{
  class OrderBy
  {
    public static void Exec()
    {
      CostCourse[] CostCourseData = new CostCourse[] {
        new CostCourse{ course_code = "0054010100", course_name = "合同履约成本-物料成本", sub_import_amount= 0},
        new CostCourse{ course_code = "0054010200", course_name = "合同履约成本-服务成本", sub_import_amount= 0},
        new CostCourse{ course_code = "0054010301", course_name = "合同履约成本-费用-差旅费", sub_import_amount= 0},
        new CostCourse{ course_code = "0054010302", course_name = "合同履约成本-费用-业务招待费", sub_import_amount= 0},
        new CostCourse{ course_code = "0054010303", course_name = "合同履约成本-费用-市内交通费", sub_import_amount= 0},
        new CostCourse{ course_code = "0054010304", course_name = "合同履约成本-费用-其他", sub_import_amount= 0},
        new CostCourse{ course_code = "0054010401", course_name = "合同履约成本-人工成本-月薪酬", sub_import_amount= 0},
        new CostCourse{ course_code = "0054010402", course_name = "合同履约成本-人工成本-T季度浮动薪酬", sub_import_amount= 0},
        new CostCourse{ course_code = "0054010402", course_name = "合同履约成本-人工成本-Z季度浮动薪酬", sub_import_amount= 0},
        new CostCourse{ course_code = "0054010403", course_name = "合同履约成本-人工成本-住房公积金", sub_import_amount= 0},
        new CostCourse{ course_code = "0054010404", course_name = "合同履约成本-人工成本-养老保险", sub_import_amount= 0},
        new CostCourse{ course_code = "0054010405", course_name = "合同履约成本-人工成本-工伤保险", sub_import_amount= 0},
        new CostCourse{ course_code = "0054010406", course_name = "合同履约成本-人工成本-生育保险", sub_import_amount= 0},
        new CostCourse{ course_code = "0054010407", course_name = "合同履约成本-人工成本-失业保险", sub_import_amount= 0},
        new CostCourse{ course_code = "0054010408", course_name = "合同履约成本-人工成本-医疗保险", sub_import_amount= 0},
        new CostCourse{ course_code = "0054010409", course_name = "合同履约成本-人工成本-补充医疗保险", sub_import_amount= 0},
      };

      var result = CostCourseData.OrderBy(x => x.course_name).ToList();
      Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
    }
  }

  class CostCourse
  {
    public int sub_import_amount { set; get; }
    public string course_code { set; get; }
    public string course_name { set; get; }
  }
}
