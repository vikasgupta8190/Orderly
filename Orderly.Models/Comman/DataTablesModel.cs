using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Models
{
    public class DataTablesModel
    {
        #region Const

        protected const string DEFAULT_PAGING_TYPE = "simple_numbers";

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        public DataTablesModel()
        {
            //set default values
            Info = true;
            RefreshButton = true;
            ServerSide = true;
            Processing = true;
            Paging = true;
            AfterSuccess = string.Empty;
            PagingType = DEFAULT_PAGING_TYPE;
            Filters = new List<FilterParameter>();
            ColumnCollection = new List<ColumnProperty>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets table name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets URL for data read (ajax)
        /// </summary>
        public string UrlRead { get; set; }

        /// <summary>
        /// Gets or sets URL for delete action (ajax)
        /// </summary>
        public string UrlDelete { get; set; }

        /// <summary>
        /// Gets or sets URL for update action (ajax)
        /// </summary>
        public string UrlUpdate { get; set; }

        /// <summary>
        /// Gets or sets search button Id
        /// </summary>
        public string SearchButtonId { get; set; }

        /// <summary>
        /// Gets or set filters controls
        /// </summary>
        public IList<FilterParameter> Filters { get; set; }

        /// <summary>
        /// Gets or sets data for table (ajax, json, array)
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Enable or disable the display of a 'processing' indicator when the table is being processed 
        /// </summary>
        public bool Processing { get; set; }

        /// <summary>
        /// Feature control DataTables' server-side processing mode
        /// </summary>
        public bool ServerSide { get; set; }

        /// <summary>
        /// Enable or disable table pagination.
        /// </summary>
        public bool Paging { get; set; }

        /// <summary>
        /// Enable or disable information ("1 to n of n entries")
        /// </summary>
        public bool Info { get; set; }

        /// <summary>
        /// Call this method after dataload
        /// </summary>
        public string AfterSuccess { get; set; }


        /// <summary>
        /// If set, populate the row id based on the specified field
        /// </summary>
        public string RowIdBasedOnField { get; set; }

        /// <summary>
        /// Enable or disable refresh button
        /// </summary>
        public bool RefreshButton { get; set; }

        /// <summary>
        /// Pagination button display options.
        /// </summary>
        public string PagingType { get; set; }

        /// <summary>
        /// Number of rows to display on a single page when using pagination
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// This parameter allows you to readily specify the entries in the length drop down select list that DataTables shows when pagination is enabled
        /// </summary>
        public string LengthMenu { get; set; }

        /// <summary>
        /// Indicates where particular features appears in the DOM
        /// </summary>
        public string Dom { get; set; }

        /// <summary>
        /// Feature control ordering (sorting) abilities in DataTables
        /// </summary>
        public bool Ordering { get; set; }

        /// <summary>
        /// Gets or sets custom render header function name(js)
        /// See also https://datatables.net/reference/option/headerCallback
        /// </summary>
        public string HeaderCallback { get; set; }

        /// <summary>
        /// Gets or sets a number of columns to generate in a footer. Set 0 to disable footer
        /// </summary>
        public int FooterColumns { get; set; }

        /// <summary>
        /// Gets or sets custom render footer function name(js)
        /// See also https://datatables.net/reference/option/footerCallback
        /// </summary>
        public string FooterCallback { get; set; }

        /// <summary>
        /// Gets or sets indicate of child table
        /// </summary>
        public bool IsChildTable { get; set; }

        /// <summary>
        /// Gets or sets child table
        /// </summary>
        public DataTablesModel ChildTable { get; set; }

        /// <summary>
        /// Gets or sets primary key column name for parent table
        /// </summary>
        public string PrimaryKeyColumn { get; set; }

        /// <summary>
        /// Gets or sets bind column name for delete action. If this field is not specified, the default will be the alias "id" for the delete action
        /// </summary>
        public string BindColumnNameActionDelete { get; set; }

        /// <summary>
        /// Gets or set column collection 
        /// </summary>
        public IList<ColumnProperty> ColumnCollection { get; set; }

        #endregion
    }

    #region Helper Classes
    public partial class ColumnProperty
    {
        #region Ctor

        /// <summary>
        /// Initializes a new instance of the ColumnProperty class
        /// </summary>
        /// <param name="data">The data source for the column from the rows data object</param>
        public ColumnProperty(string data)
        {
            Data = data;
            //set default values
            Visible = true;
            Encode = true;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Set the data source for the column from the rows data object / array.
        /// See also "https://datatables.net/reference/option/columns.data"
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// Set the column title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Render (process) the data for use in the table. This property will modify the data that is used by DataTables for various operations.
        /// </summary>
        public IRender Render { get; set; }

        /// <summary>
        /// Column width assignment. This parameter can be used to define the width of a column, and may take any CSS value (3em, 20px etc).
        /// </summary>
        public string Width { get; set; }

        /// <summary>
        /// Column autowidth assignment. This can be disabled as an optimisation (it takes a finite amount of time to calculate the widths) if the tables widths are passed in using "width".
        /// </summary>
        public bool AutoWidth { get; set; }

        /// <summary>
        /// Indicate whether the column is master check box
        /// </summary>
        public bool IsMasterCheckBox { get; set; }

        /// <summary>
        /// Class to assign to each cell in the column.
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// Enable or disable the display of this column.
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// Enable or disable filtering on the data in this column.
        /// </summary>
        public bool Searchable { get; set; }

        /// <summary>
        /// Enable or disable editing on the data in this column.
        /// </summary>
        public bool Editable { get; set; }

        /// <summary>
        /// Data column type
        /// </summary>
        public EditType EditType { get; set; }

        /// <summary>
        /// Enable or disable encode on the data in this column.
        /// </summary>
        public bool Encode { get; set; }

        #endregion
    }

    public partial interface IRender
    {
    }

    /// <summary>
    /// Represents type editing of column
    /// </summary>
    public enum EditType
    {
        Number = 1,
        Checkbox = 2,
        String = 3
    }
    #endregion

    #region Renders
    /// <summary>
    /// Represents date render for DataTables column
    /// </summary>
    public partial class RenderDate : IRender
    {
        #region Constants

        /// <summary>
        /// Default date format
        /// </summary>
        /// <remarks>For example english culture: [MM/DD/YYYY h:mm:ss PM/AM] [09/04/1986 8:30:25 PM]</remarks>
       // private string DEFAULT_DATE_FORMAT = "L LTS";
        private string DEFAULT_DATE_FORMAT = "DD/MM/YYYY HH:mm:ss";

        #endregion

        #region Ctor

        public RenderDate()
        {
            //set default values
            Format = DEFAULT_DATE_FORMAT;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets format date (moment.js)
        /// See also "http://momentjs.com/"
        /// </summary>
        public string Format { get; set; }

        #endregion
    }

    /// <summary>
    /// Represents button render for DataTables column
    /// </summary>
    public partial class RenderButtonRemove : IRender
    {
        #region Ctor

        /// <summary>
        /// Initializes a new instance of the RenderButton class 
        /// </summary>
        /// <param name="title">Button title</param>
        public RenderButtonRemove(string title)
        {
            Title = title;
            ClassName = "btn-orderly-gird";
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets button title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets button class name
        /// </summary>
        public string ClassName { get; set; }

        #endregion
    }

    /// <summary>
    /// Represents button render for DataTables column
    /// </summary>
    public partial class RenderButtonsInlineEdit : IRender
    {
        #region Ctor

        /// <summary>
        /// Initializes a new instance of the RenderButton class 
        /// </summary>
        public RenderButtonsInlineEdit()
        {
            ClassName = "btn-orderly-gird";
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets button class name
        /// </summary>
        public string ClassName { get; set; }

        #endregion
    }

    /// <summary>
    /// Represents button edit render for DataTables column
    /// </summary>
    public partial class RenderButtonEdit : IRender
    {
        #region Ctor

        /// <summary>
        /// Initializes a new instance of the RenderButtonEdit class 
        /// </summary>
        /// <param name="url">URL to the edit action</param>
        public RenderButtonEdit(string url)
        {
            Url = url;
            ClassName = "btn-orderly-gird";
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets Url to action edit
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets button class name
        /// </summary>
        public string ClassName { get; set; }

        #endregion
    }

    /// <summary>
    /// Represents button view render for DataTables column
    /// </summary>
    public partial class RenderButtonView : IRender
    {
        #region Ctor

        /// <summary>
        /// Initializes a new instance of the RenderButtonEdit class 
        /// </summary>
        /// <param name="url">URL to the edit action</param>
        public RenderButtonView(string url, string onclickAction = "")
        {
            Url = url;
            ClassName = "btn btn-outline-info";
            OnClickAction = onclickAction;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets Url to action edit
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets button class name
        /// </summary>
        public string ClassName { get; set; }

        public string OnClickAction { get; set; }

        #endregion
    }

    /// <summary>
    /// Represents button custom render for DataTables column
    /// </summary>
    public partial class RenderButtonCustom : IRender
    {
        #region Ctor

        /// <summary>
        /// Initializes a new instance of the RenderButtonEdit class 
        /// </summary>
        /// <param name="className">Class name of button</param>
        /// <param name="title">Title button</param>
        public RenderButtonCustom(string className, string title)
        {
            ClassName = className;
            Title = title;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets Url to action
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets button class name
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// Gets or sets button title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets function name on click button
        /// </summary>
        public string OnClickFunctionName { get; set; }

        #endregion
    }

    /// <summary>
    /// Represents picture render for DataTables column
    /// </summary>
    public partial class RenderPicture : IRender
    {
        #region Ctor

        public RenderPicture(string srcPrefix = "", int width = 0)
        {
            SrcPrefix = srcPrefix;
            Width = width;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets picture URL prefix
        /// </summary>
        public string SrcPrefix { get; set; }

        /// <summary>
        /// Gets or sets picture source
        /// </summary>
        public string Src { get; set; }

        /// <summary>
        /// Gets or sets picture width
        /// </summary>
        public int Width { get; set; }

        #endregion
    }

    /// <summary>
    /// Represents checkbox render for DataTables column
    /// </summary>
    public partial class RenderCheckBox : IRender
    {
        #region Ctor

        /// <summary>
        /// Initializes a new instance of the RenderCheckBox class 
        /// </summary>
        /// <param name="name">Checkbox name</param>
        /// <param name="propertyKeyName">Property key name ("Id" by default). This property must be defined in the row dataset.</param>
        public RenderCheckBox(string name, string propertyKeyName = "Id")
        {
            Name = name;
            PropertyKeyName = propertyKeyName;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets name checkbox
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets identificator for row 
        /// </summary>
        public string PropertyKeyName { get; set; }

        #endregion
    }

    /// <summary>
    /// Represents boolean render for DataTables column
    /// </summary>
    public partial class RenderBoolean : IRender
    {
    }

    /// <summary>
    /// Represents custom render for DataTables column
    /// </summary>
    public partial class RenderCustom : IRender
    {
        #region Ctor

        /// <summary>
        /// Initializes a new instance of the RenderCustom class 
        /// </summary>
        /// <param name="functionName">Custom render function name that is used in js</param>
        public RenderCustom(string functionName)
        {
            FunctionName = functionName;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets custom render function name(js)
        /// See also https://datatables.net/reference/option/columns.render
        /// </summary>
        public string FunctionName { get; set; }

        #endregion
    }

    /// <summary>
    /// Represents caret render for DataTables column
    /// </summary>
    public partial class RenderChildCaret : IRender
    {
    }

    /// <summary>
    /// Represent DataTables filter parameter
    /// </summary>
    public partial class FilterParameter
    {
        #region Ctor

        /// <summary>
        /// Initializes a new instance of the FilterParameter class by default as string type parameter
        /// </summary>
        /// <param name="name">Filter parameter name</param>
        public FilterParameter(string name)
        {
            Name = name;
            Type = typeof(string);
        }

        /// <summary>
        /// Initializes a new instance of the FilterParameter class
        /// </summary>
        /// <param name="name">Filter parameter name</param>
        /// <param name="modelName">Filter parameter model name</param>
        public FilterParameter(string name, string modelName)
        {
            Name = name;
            ModelName = modelName;
            Type = typeof(string);
        }

        /// <summary>
        /// Initializes a new instance of the FilterParameter class
        /// </summary>
        /// <param name="name">Filter parameter name</param>
        /// <param name="type">Filter parameter type</param>
        public FilterParameter(string name, Type type)
        {
            Name = name;
            Type = type;
        }

        /// <summary>
        /// Initializes a new instance of the FilterParameter class
        /// </summary>
        /// <param name="name">Filter parameter name</param>
        /// <param name="value">Filter parameter value</param>
        public FilterParameter(string name, object value)
        {
            Name = name;
            Type = value.GetType();
            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the FilterParameter class for linking "parent-child" tables
        /// </summary>
        /// <param name="name">Filter parameter name</param>
        /// <param name="parentName">Filter parameter parent name</param>
        /// <param name="isParentChildParameter">Parameter indicator for linking "parent-child" tables</param>
        public FilterParameter(string name, string parentName, bool isParentChildParameter = true)
        {
            Name = name;
            ParentName = parentName;
            Type = typeof(string);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Filter field name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Filter model name
        /// </summary>
        public string ModelName { get; }

        /// <summary>
        /// Filter field type
        /// </summary>
        public Type Type { get; }

        /// <summary>
        /// Filter field value
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Filter field parent name
        /// </summary>
        public string ParentName { get; set; }

        #endregion
    }
    #endregion


}
