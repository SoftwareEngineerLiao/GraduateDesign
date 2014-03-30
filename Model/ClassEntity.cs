using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Commons;

namespace Model
{
    /// <summary>
    /// 实体类：ClassEntity。
    ///</summary>
    [Serializable]
    public class ClassEntity
    {
        #region 存储字段。
        private string _class_no;
        private string _academy_no;
        private string _major;
        private int _number;
        #endregion

        #region 初始化 clas 类的新实例。
        /// <summary>
        /// 初始化 clas" /> 类的新实例。
        ///</summary>
        public ClassEntity()
        {
            _class_no = string.Empty;
            _academy_no = string.Empty;
            _major = string.Empty;
            _number = 0;
        }
        #endregion

        #region 获取或设置
        ///<summary>
        ///获取或设置
        ///</summary>
        ///<value></value>
        public string class_no
        {
            get { return _class_no; }
            set { _class_no = value; }
        }
        #endregion

        #region 获取或设置
        ///<summary>
        ///获取或设置
        ///</summary>
        ///<value></value>
        public string academy_no
        {
            get { return _academy_no; }
            set { _academy_no = value; }
        }
        #endregion

        #region 获取或设置
        ///<summary>
        ///获取或设置
        ///</summary>
        ///<value></value>
        public string major
        {
            get { return _major; }
            set { _major = value; }
        }
        #endregion

        #region 获取或设置
        ///<summary>
        ///获取或设置
        ///</summary>
        ///<value></value>
        public int number
        {
            get { return _number; }
            set { _number = value; }
        }
        #endregion

    }
}

