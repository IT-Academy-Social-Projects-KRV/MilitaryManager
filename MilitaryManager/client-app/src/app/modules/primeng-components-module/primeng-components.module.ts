import { NgModule } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { TabMenuModule } from 'primeng/tabmenu';
import { PanelModule } from 'primeng/panel';
import { TableModule } from 'primeng/table';
import { FieldsetModule } from 'primeng/fieldset';
import { ToolbarModule } from 'primeng/toolbar';
import { InputMaskModule } from 'primeng/inputmask';
import { PasswordModule } from 'primeng/password';
import { CheckboxModule } from 'primeng/checkbox';
import { InputSwitchModule } from 'primeng/inputswitch';
import { ScrollPanelModule } from 'primeng/scrollpanel';
import { TreeTableModule } from 'primeng/treetable';
import { DropdownModule } from 'primeng/dropdown';
import { HttpClientModule } from '@angular/common/http';
import { DialogModule } from 'primeng/dialog';
import { ToastModule } from 'primeng/toast';
import { ColorPickerModule } from 'primeng/colorpicker';
import { BreadcrumbModule } from 'primeng/breadcrumb';
import { MessageService } from 'primeng/api';
import { MenuModule } from 'primeng/menu';
import { SidebarModule } from 'primeng/sidebar';
import { PanelMenuModule } from 'primeng/panelmenu';
import { TooltipModule } from 'primeng/tooltip';
import { SplitButtonModule } from 'primeng/splitbutton';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmationService } from 'primeng/api';
import { StepsModule } from 'primeng/steps';
import { SpinnerModule } from 'primeng/spinner';
import { SelectButtonModule } from 'primeng/selectbutton';
import { ListboxModule } from 'primeng/listbox';
import { MultiSelectModule } from 'primeng/multiselect';
import { SliderModule } from 'primeng/slider';
import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { AccordionModule } from 'primeng/accordion';
import { ContextMenuModule } from 'primeng/contextmenu';
import { TreeModule } from 'primeng/tree';
import { CalendarModule } from 'primeng/calendar';
import { InputTextModule } from 'primeng/inputtext';
import { TagModule } from 'primeng/tag';
import { AvatarModule } from 'primeng/avatar';
import { OverlayPanelModule } from 'primeng/overlaypanel';
import { TerminalModule } from 'primeng/terminal';
import { TabViewModule } from 'primeng/tabview';
import { MenubarModule } from 'primeng/menubar';
import {SlideMenuModule} from 'primeng/slidemenu';
import { FormsModule } from '@angular/forms';


const primeNgModules = [
  ButtonModule,
  CardModule,
  TabMenuModule,
  PanelModule,
  TableModule,
  FieldsetModule,
  ToolbarModule,
  InputMaskModule,
  PasswordModule,
  CheckboxModule,
  InputSwitchModule,
  ScrollPanelModule,
  TreeTableModule,
  DropdownModule,
  HttpClientModule,
  DialogModule,
  ToastModule,
  ColorPickerModule,
  BreadcrumbModule,
  MenuModule,
  SidebarModule,
  PanelMenuModule,
  TooltipModule,
  SplitButtonModule,
  ConfirmDialogModule,
  StepsModule,
  SpinnerModule,
  SelectButtonModule,
  ListboxModule,
  MultiSelectModule,
  SliderModule,
  MessagesModule,
  MessageModule,
  ProgressSpinnerModule,
  CalendarModule,
  InputTextareaModule,
  AccordionModule,
  ContextMenuModule,
  TreeModule,
  InputTextModule,
  TagModule,
  AvatarModule,
  OverlayPanelModule,
  TerminalModule,
  TabViewModule,
  MenubarModule,
  SlideMenuModule,
  FormsModule
];
@NgModule({
  imports: [
    ...primeNgModules
  ],
  exports: [
    ...primeNgModules
  ],
  providers: [
    MessageService,
    ConfirmationService
  ]
})
export class PrimeNgComponentsModule { }
