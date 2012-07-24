<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="CodeExService" generation="1" functional="0" release="0" Id="b26298f9-44d4-4fc0-bf10-e9fcd36ba5fd" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="CodeExServiceGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="HoiioWCFService:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/CodeExService/CodeExServiceGroup/LB:HoiioWCFService:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="HoiioWCFService:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/CodeExService/CodeExServiceGroup/MapHoiioWCFService:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="HoiioWCFServiceInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/CodeExService/CodeExServiceGroup/MapHoiioWCFServiceInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:HoiioWCFService:Endpoint1">
          <toPorts>
            <inPortMoniker name="/CodeExService/CodeExServiceGroup/HoiioWCFService/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapHoiioWCFService:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/CodeExService/CodeExServiceGroup/HoiioWCFService/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapHoiioWCFServiceInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/CodeExService/CodeExServiceGroup/HoiioWCFServiceInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="HoiioWCFService" generation="1" functional="0" release="0" software="C:\Users\Owner\documents\visual studio 2010\Projects\CodeExService\CodeExService\csx\Debug\roles\HoiioWCFService" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;HoiioWCFService&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;HoiioWCFService&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="WCFServiceWebRole1.svclog" defaultAmount="[1000,1000,1000]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/CodeExService/CodeExServiceGroup/HoiioWCFServiceInstances" />
            <sCSPolicyFaultDomainMoniker name="/CodeExService/CodeExServiceGroup/HoiioWCFServiceFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyFaultDomain name="HoiioWCFServiceFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="HoiioWCFServiceInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="42adbd3b-4bc1-491f-829f-3a16905d5e63" ref="Microsoft.RedDog.Contract\ServiceContract\CodeExServiceContract@ServiceDefinition.build">
      <interfacereferences>
        <interfaceReference Id="44c88c7b-bf3e-4210-a943-3f81c5e42e3f" ref="Microsoft.RedDog.Contract\Interface\HoiioWCFService:Endpoint1@ServiceDefinition.build">
          <inPort>
            <inPortMoniker name="/CodeExService/CodeExServiceGroup/HoiioWCFService:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>