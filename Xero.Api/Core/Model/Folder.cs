using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Xero.Api.Core.Model
{
  [DataContract(Namespace = "")]
  public class Folder
  {
    [DataMember(EmitDefaultValue = false)]
    public string Name { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public Guid Id { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public bool IsInbox { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public int FileCount { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public List<Model.File> Files { get; set; }
  }
}