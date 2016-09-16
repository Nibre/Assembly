using System;

namespace Assembly.Metro.Controls.PageTemplates.Games.Components.MetaData
{
    public enum VectorType
    {
        Vector2 = 2,
        Vector3 = 3,
        Vector4 = 4
    }
    public class VectorData : ValueField
	{
		private float _x, _y, _z, _a;
        private string _labels;
        private string _xLabel, _yLabel, _zLabel, _aLabel;
        private bool _zVis, _aVis;
        private string _typeLabel;
        private bool _degrees;

        public VectorData(string name, uint offset, uint address, VectorType type, float x, float y, float z, float a, string labels, bool degrees, uint pluginLine)
            : base(name, offset, address, pluginLine)
        {
            // Vector Components
            _x = x;
            _y = y;
            _z = z;
            _a = a;


            // Visibility for last 2 Components
            _zVis = _aVis = false;

            _labels = labels;
            _degrees = degrees;
            
            // Optional custom label letters for components
            if (_labels.Length < (int)type)
            {
                _xLabel = "x";
                _yLabel = "y";
                _zLabel = "z";
                _aLabel = "a";
            }
            else
            {
                switch (type)
                {
                    case VectorType.Vector4:
                        _aLabel = _labels[3].ToString();
                        goto case VectorType.Vector3;
                    case VectorType.Vector3:
                        _zLabel = _labels[2].ToString();
                        goto case VectorType.Vector2;
                    case VectorType.Vector2:
                        _yLabel = _labels[1].ToString();
                        goto default;
                    default:
                        _xLabel = _labels[0].ToString();
                        break;
                }
            }

            // Make last 2 Components visible if we need either
            switch (type)
            {
                case VectorType.Vector4:
                    _aVis = true;
                    goto case VectorType.Vector3;
                case VectorType.Vector3:
                    _zVis = true;
                    break;
            }

            // Create our Vector type name
            _typeLabel = "vector";
            switch (type)
            {
                case VectorType.Vector4:
                    _typeLabel += "4";
                    break;
                case VectorType.Vector3:
                    _typeLabel += "3";
                    break;
                case VectorType.Vector2:
                    _typeLabel += "2";
                    break;
            }

            if (_degrees)
                _typeLabel += "D";
            else
                _typeLabel += "F";
        }
        

        // XVal - For exposing the editable 'value' to the Field (so we can switch to Degrees if we want)
        // X - The true value, for reading/saving from the Cache
        public float XVal
        {
            get
            {
                if (_degrees)
                    return (float)(_x * (180 / Math.PI));
                else
                    return _x;
            }
            set
            {
                if (_degrees)
                    _x = (float)(value * (Math.PI / 180));
                else
                    _x = value;

                NotifyPropertyChanged("X");
                NotifyPropertyChanged("XVal");
            }
        }

        public float X
		{
			get
            {
                return _x;
            }
			set
			{
                _x = value;
				NotifyPropertyChanged("X");
                NotifyPropertyChanged("XVal");
            }
        }

        public float YVal
        {
            get
            {
                if (_degrees)
                    return (float)(_y * (180 / Math.PI));
                else
                    return _y;
            }
            set
            {
                if (_degrees)
                    _y = (float)(value * (Math.PI / 180));
                else
                    _y = value;

                NotifyPropertyChanged("Y");
                NotifyPropertyChanged("YVal");
            }
        }

        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
                NotifyPropertyChanged("Y");
                NotifyPropertyChanged("YVal");
            }
        }

        public float ZVal
        {
            get
            {
                if (_degrees)
                    return (float)(_z * (180 / Math.PI));
                else
                    return _z;
            }
            set
            {
                if (_degrees)
                    _z = (float)(value * (Math.PI / 180));
                else
                    _z = value;

                NotifyPropertyChanged("Z");
                NotifyPropertyChanged("ZVal");
            }
        }

        public float Z
        {
            get
            {
                return _z;
            }
            set
            {
                _z = value;
                NotifyPropertyChanged("Z");
                NotifyPropertyChanged("ZVal");
            }
        }

        public float AVal
        {
            get
            {
                if (_degrees)
                    return (float)(_a * (180 / Math.PI));
                else
                    return _a;
            }
            set
            {
                if (_degrees)
                    _a = (float)(value * (Math.PI / 180));
                else
                    _a = value;

                NotifyPropertyChanged("A");
                NotifyPropertyChanged("AVal");
            }
        }

        public float A
        {
            get
            {
                return _a;
            }
            set
            {
                _a = value;
                NotifyPropertyChanged("A");
                NotifyPropertyChanged("AVal");
            }
        }

        // Labels that we can change
        public string XLabel
        {
            get { return _xLabel; }
            set
            {
                _xLabel = value;
                NotifyPropertyChanged("XLabel");
            }
        }

        public string YLabel
        {
            get { return _yLabel; }
            set
            {
                _yLabel = value;
                NotifyPropertyChanged("YLabel");
            }
        }

        public string ZLabel
        {
            get { return _zLabel; }
            set
            {
                _zLabel = value;
                NotifyPropertyChanged("ZLabel");
            }
        }

        public string ALabel
        {
            get { return _aLabel; }
            set
            {
                _aLabel = value;
                NotifyPropertyChanged("ALabel");
            }
        }

        // Visibility
        public System.Windows.Visibility ZVis
        {
            get
            {
                if (_zVis)
                    return System.Windows.Visibility.Visible;
                else
                    return System.Windows.Visibility.Collapsed;
            }
        }

        public System.Windows.Visibility AVis
        {
            get
            {
                if (_aVis)
                    return System.Windows.Visibility.Visible;
                else
                    return System.Windows.Visibility.Collapsed;
            }
        }

        // Vector type
        public string TypeLabel
        {
            get { return _typeLabel; }
            set
            {
                _typeLabel = value;
                NotifyPropertyChanged("TypeLabel");
            }
        }

        public override void Accept(IMetaFieldVisitor visitor)
		{
			visitor.VisitVector(this);
		}

		public override MetaField CloneValue()
		{
			return new VectorData(Name, Offset, FieldAddress, VectorType.Vector3, _x, _y, _z, _a, _labels, _degrees, base.PluginLine);
		}
	}
}