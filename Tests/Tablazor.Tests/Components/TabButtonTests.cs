using System.Collections.Generic;
using FluentAssertions;
using Tablazor.Common;

namespace Tablazor.Components;

public class TabButtonTests : TestContext
{
    private const string ButtonText = "My Button";
    
    [Fact(DisplayName = "Render :: Default Button")]
    public void ShouldRenderDefaultButton()
    {
        var component = RenderComponent<TabButton>(parameters => parameters
            .Add(x => x.Text, ButtonText)
        );
        
        var button = component.Find("button");

        button.ClassName.Should().Be("btn");
        
        button.Attributes["id"].Should().NotBeNull();
        button.Attributes["type"].Should().NotBeNull();
        
        button.Attributes["type"]!.Value.Should().Be("button");
        button.Attributes["id"]!.Value.Should().Be(component.Instance.Id);
        
        button.InnerHtml.Should().Be(ButtonText);
    }

    [Fact(DisplayName = "Render :: Link Button")]
    public void ShouldRenderALinkButton()
    {
        var component = RenderComponent<TabButton>(parameters => parameters
            .Add(x => x.Text, ButtonText)
            .Add(x => x.ButtonType, ButtonType.Link)
        );

        var button = component.Find("a");

        button.ClassName.Should().Be("btn");

        button.Attributes["id"].Should().NotBeNull();
        button.Attributes["role"].Should().NotBeNull();
        button.Attributes["href"].Should().NotBeNull();

        button.Attributes["id"]!.Value.Should().Be(component.Instance.Id);
        button.Attributes["role"]!.Value.Should().Be("button");
        button.Attributes["href"]!.Value.Should().Be("#");
        
        button.InnerHtml.Should().Be(ButtonText);
    }
    
    [Fact(DisplayName = "Render :: Input Button")]
    public void ShouldRenderAnInputButton()
    {
        var component = RenderComponent<TabButton>(parameters => parameters
            .Add(x => x.Text, ButtonText)
            .Add(x => x.ButtonType, ButtonType.Input)
        );
        
        var button = component.Find("input");

        button.ClassName.Should().Be("btn");
        
        button.Attributes["id"].Should().NotBeNull();
        button.Attributes["type"].Should().NotBeNull();
        button.Attributes["value"].Should().NotBeNull();
        
        button.Attributes["id"]!.Value.Should().Be(component.Instance.Id);
        button.Attributes["type"]!.Value.Should().Be("input");
        button.Attributes["value"]!.Value.Should().Be(ButtonText);
    }
    
    [Fact(DisplayName = "Render :: Submit Button")]
    public void ShouldRenderASubmitButton()
    {
        var component = RenderComponent<TabButton>(parameters => parameters
            .Add(x => x.Text, ButtonText)
            .Add(x => x.ButtonType, ButtonType.Submit)
        );
        
        var button = component.Find("input");

        button.ClassName.Should().Be("btn");
        
        button.Attributes["id"].Should().NotBeNull();
        button.Attributes["type"].Should().NotBeNull();
        button.Attributes["value"].Should().NotBeNull();
        
        button.Attributes["id"]!.Value.Should().Be(component.Instance.Id);
        button.Attributes["type"]!.Value.Should().Be("submit");
        button.Attributes["value"]!.Value.Should().Be(ButtonText);
    }
    
    [Fact(DisplayName = "Render :: Reset Button")]
    public void ShouldRenderAResetButton()
    {
        var component = RenderComponent<TabButton>(parameters => parameters
            .Add(x => x.Text, ButtonText)
            .Add(x => x.ButtonType, ButtonType.Reset)
        );
        
        var button = component.Find("input");

        button.ClassName.Should().Be("btn");
        
        button.Attributes["id"].Should().NotBeNull();
        button.Attributes["type"].Should().NotBeNull();
        button.Attributes["value"].Should().NotBeNull();
        
        button.Attributes["id"]!.Value.Should().Be(component.Instance.Id);
        button.Attributes["type"]!.Value.Should().Be("reset");
        button.Attributes["value"]!.Value.Should().Be(ButtonText);
    }
    
    [Fact(DisplayName = "Render :: Ghost Button Defaults")]
    public void ShouldRenderAGhostButton()
    {
        var component = RenderComponent<TabButton>(parameters => parameters
            .Add(x => x.Text, ButtonText)
            .Add(x => x.Ghost, true)
        );
        
        var button = component.Find("button");

        button.ClassName.Should().Be("btn btn-ghost-primary");
        
        button.Attributes["id"].Should().NotBeNull();
        button.Attributes["type"].Should().NotBeNull();
        
        button.Attributes["id"]!.Value.Should().Be(component.Instance.Id);
        button.Attributes["type"]!.Value.Should().Be("button");
    }
    
    [Fact(DisplayName = "Render :: Outlined Button")]
    public void ShouldRenderAnOutlinedButton()
    {
        var component = RenderComponent<TabButton>(parameters => parameters
            .Add(x => x.Text, ButtonText)
            .Add(x => x.Outlined, true)
        );
        
        var button = component.Find("button");

        button.ClassName.Should().Be("btn btn-outline-primary");
        
        button.Attributes["id"].Should().NotBeNull();
        button.Attributes["type"].Should().NotBeNull();
        
        button.Attributes["id"]!.Value.Should().Be(component.Instance.Id);
        button.Attributes["type"]!.Value.Should().Be("button");
    }

    [Fact(DisplayName = "Render :: Custom Class")]
    public void ShouldRenderAButtonWithACustomClass()
    {
        var component = RenderComponent<TabButton>(parameters => parameters
            .Add(x => x.Text, ButtonText)
            .Add(x => x.Attributes, new Dictionary<string, object>() { { "class", "mybtn" } })
        );
        
        var button = component.Find("button");

        button.ClassName.Should().Be("mybtn btn");
    }
}